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
    public bool isUsed;

    public Chair(GameObject gameObject)
    {
        this.chairGameObject = gameObject;
        this.isUsed = false;
    }


    public void SitOnItAndUpdatePlayer(Player player)
    {
        this.isUsed = true;
        this.playerSited = player;
        player.MakeAnimationsAndUpdatePlayerPosition(this.chairGameObject.GetComponent<RectTransform>());
        if (ChairController.CanMakeAPlayerGoToBalcony())
        {
            ChairController.SendFirstPlayerToBalcony();
        }
    }

    public void DisposeIt()
    {
        this.isUsed = false;
        this.chairGameObject = default;
    }
}

