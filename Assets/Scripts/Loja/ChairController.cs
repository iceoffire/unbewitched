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

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        if (StoreSceneInfo.hasChangedSceneAtLeastOneTime)
        {
            chairMiddlePosition = new List<Chair>();
            LoadChairs();
            OverrideChairsWithOldOlder(StoreSceneInfo.playersInfo);
        }
        else
        {
            LoadChairs();
        }
    }

    private void LoadChairs()
    {
        foreach (Transform transform in transform)
        {
            chairMiddlePosition.Add(new Chair(transform.gameObject));
        }
    }

    private void OverrideChairsWithOldOlder(List<PlayerDiagnosticInfo> playerDiagnosticInfos)
    {
        foreach(PlayerDiagnosticInfo playerDiagnosticInfo in playerDiagnosticInfos)
        {
            if (ThereIsAnyFreeChairToGet())
            {
                Chair freeChair = GetFirstChairFree();
                SpawnPlayerOnStore.SpawnInChairWithoutAnimation(freeChair, playerDiagnosticInfo);
            }
        }
    }

    public static bool CanMakeAPlayerGoToBalcony()
    {
        return singleton.isBalconyDisponible;
    }

    public static void SendFirstPlayerToBalcony()
    {
        try
        {
            SetBalconyNotDisponible();
            Chair firstChairInfo = GetFirstChairUsed();
            AnimateAndUpdatePlayerPosition(firstChairInfo);
            MakePlayerInteractable(firstChairInfo.playerSited);
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

    private static void UpdateAllPlayersToNextChair()
    {
        // further -> make it.
    }

    private static Chair GetFirstChairUsed()
    {
        if (chairMiddlePosition.Count(x => x.chairGameObject == null) > 0)
        {
            throw new Exception("Stop");
        }
        Chair chair = chairMiddlePosition.OrderBy(x => x.chairGameObject.transform.position.x).FirstOrDefault(x => x.isUsed);
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
}
