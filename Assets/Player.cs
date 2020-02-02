using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

[Serializable]
public class Player : MonoBehaviour
{
    public BodyPart head;
    public BodyPart torso;
    public BodyPart arms;
    public BodyPart legs;
    public bool isOnBalcony
    {
        get
        {
            return isActivable;
        }
    }
    public bool isActivable=false;
        
    public PlayerDiagnosticInfo playerDiagnosticInfo;

    public void UpdateValuesAndDraw(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        this.playerDiagnosticInfo = playerDiagnosticInfo;
        UpdateHead(playerDiagnosticInfo.head);
        UpdateTorso(playerDiagnosticInfo.torso);
        UpdateArm(playerDiagnosticInfo.arm);
        UpdateLeg(playerDiagnosticInfo.leg);
        isActivable = false;
    }

    public void MakeAnimationsAndUpdatePlayerPosition(RectTransform destination)
    {
        StartCoroutine(_Animate(destination));
    }

    private IEnumerator _Animate(RectTransform destination)
    {
        DoFadeIn();
        yield return new WaitForSeconds(2);
        Vector3 finalDestination = destination.position;
        finalDestination.y = this.transform.position.y;
        this.transform.DOMove(finalDestination, 1);
    }

    private void OnMouseDown()
    {
        if (isActivable)
        {
            // further -> call transition
            DiagnosticSceneInformation.LoadInformation(this.playerDiagnosticInfo);
            SpawnPlayerOnStore.StopCoroutines();
            StoreSceneInfo.SaveOldInformation(ChairController.GetChairsInfo(), this.playerDiagnosticInfo);
            SceneManager.LoadScene((int)SceneIndexes.Diagnostico);
        }
    }

    public void SetActivable()
    {
        isActivable = true;
    }

    public void DoFadeIn()
    {
        head.image.color = new Color(0, 0, 0, 0);
        head.image.DOColor(new Color(1, 1, 1, 1), 1);

        torso.image.color = new Color(0, 0, 0, 0);
        torso.image.DOColor(new Color(1, 1, 1, 1), 1);

        arms.image.color = new Color(0, 0, 0, 0);
        arms.image.DOColor(new Color(1, 1, 1, 1), 1);

        legs.image.color = new Color(0, 0, 0, 0);
        legs.image.DOColor(new Color(1, 1, 1, 1), 1);
    }

    void UpdateHead(BodyInformation bodyInformation)
    {
        this.head.LoadArt(bodyInformation);
    }

    void UpdateTorso(BodyInformation bodyInformation)
    {
        this.torso.LoadArt(bodyInformation);
    }

    void UpdateArm(BodyInformation bodyInformation)
    {
        this.arms.LoadArt(bodyInformation);
    }

    void UpdateLeg(BodyInformation bodyInformation)
    {
        this.legs.LoadArt(bodyInformation);
    }
}
