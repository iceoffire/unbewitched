using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    static List<Chair> chairMiddlePosition = new List<Chair>();
    public GameObject positionBalcony;
    static ChairController singleton;
    public bool isBalconyDisponible;
    public static Player playerOnBalcony;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        if (StoreSceneInfo.hasChangedSceneAtLeastOneTime)
        {
            
        }
        else
        {
            LoadChairs();
        }
    }

    private void SetBalconyToDisponible()
    {
        this.isBalconyDisponible = true;
    }

    private void LoadChairs()
    {
        foreach (Transform transform in transform)
        {
            if (transform.gameObject.name == "cadeira")
            {
                chairMiddlePosition.Add(new Chair(transform.gameObject));
            }
        }
    }

    public static void OnSit()
    {
        UpdateAllPlayersToNextChair();
    }

    static void SendFirstPlayerToBalcony()
    {
        try
        {
            SetBalconyNotDisponible();
            Chair firstChairInfo = GetFirstChairUsed();
            // AnimateAndUpdatePlayerPosition(firstChairInfo);
            Vector3 finalDestination = singleton.positionBalcony.transform.position;
            finalDestination.y = firstChairInfo.playerSited.transform.position.y;
            firstChairInfo.playerSited.transform.DOMove(finalDestination, 1);
            playerOnBalcony = firstChairInfo.playerSited;
            MakePlayerInteractable(firstChairInfo.playerSited);
            firstChairInfo.SetFree();
            UpdateAllPlayersToNextChair();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    internal static List<Chair> GetChairsInfo()
    {
        return chairMiddlePosition;
    }

    private static void MakePlayerInteractable(Player playerSited)
    {
        playerSited.SetActivable();
    }

    private static void AnimateAndUpdatePlayerPosition(Chair firstChairInfo)
    {
        Vector3 finalDestination = singleton.positionBalcony.transform.position;
        finalDestination.y = firstChairInfo.playerSited.gameObject.transform.localPosition.y;
        firstChairInfo.playerSited.gameObject.transform.DOLocalMove(finalDestination, 0.4f);
    }

    private static void SetBalconyNotDisponible()
    {
        singleton.isBalconyDisponible = false;
    }

    public static void UpdateAllPlayersToNextChair()
    {
        if (singleton.isBalconyDisponible)
        {
            if (CanMakeAPlayerGoToBalcony())
            {
                SendFirstPlayerToBalcony();
            }
            UpdatePlayersSittedsToNextChair();
        }
        else
        {
            UpdatePlayersSittedsToNextChair();
        }
    }

    private static void UpdatePlayersSittedsToNextChair()
    {
        
    }


    private static Chair GetFirstChairUsed()
    {
        Chair chair = chairMiddlePosition.Where(x=>x.chairGameObject!=null).OrderBy(x => x.chairGameObject.transform.position.x).FirstOrDefault(x => x.isUsed);
        if (chair.IsDefault())
        {
            throw new Exception("Couldnt find any chair used");
        }
        else
        {
            return chair;
        }
    }

    public static Chair GetFirstChairFree()
    {
        if (chairMiddlePosition.Count(x => x.chairGameObject == null) > 0)
        {
            throw new Exception("Stop");
        }
        Chair chair = chairMiddlePosition.OrderBy(x=>x.chairGameObject.transform.position.x).FirstOrDefault(x=>!x.isUsed);
        if (!chair.IsDefault())
        {
            return chair;
        }
        else
        {
            Debug.Log("Could not found any free chair.");
            throw new System.Exception("Couldn't find any chair free");
        }
    }

    public static bool ThereIsAnyFreeChairToGet()
    {
        return chairMiddlePosition.Count(x => !x.isUsed) > 0;
    }

    public static bool CanMakeAPlayerGoToBalcony()
    {
        return singleton.isBalconyDisponible && chairMiddlePosition.Where(x=>x.playerSited).Count()>0;
    }
}
