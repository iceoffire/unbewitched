using DG.Tweening;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Chair
{
    public GameObject chairGameObject;
    public Player playerSited;
    public bool isUsed
    {
        get
        {
            return playerSited != null;
        }
    }

    public Chair(GameObject gameObject)
    {
        this.chairGameObject = gameObject;
    }


    public void SitOnItAndAnimateFadeInPlayerAndUpdatePosition(Player player)
    {
        if (player == null) return;
        this.playerSited = player;
        player.MakeAnimationsAndUpdatePlayerPosition(this.chairGameObject.GetComponent<RectTransform>());
        ChairController.UpdateAllPlayersToNextChair();
    }

    public void DisposeIt()
    {
        GameObject.Destroy(this.playerSited.gameObject);
        this.playerSited = null;
    }

    public void SetFree()
    {
        this.playerSited = null;
    }

    public void SitOnIt(Player player)
    {
        if (player == null) return;
        this.playerSited = player;
        Vector3 finalDestination = this.chairGameObject.transform.position;
        finalDestination.y = SpawnPlayerOnStore.initialY;
        // player.gameObject.transform.DOMove(finalDestination, 1);
    }
}

