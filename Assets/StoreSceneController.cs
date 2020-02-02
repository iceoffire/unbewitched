using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSceneController : MonoBehaviour
{
    void Start()
    {
        if (IsNeedToLoadSceneAgain())
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        StoreSceneInfo storeSceneInfo = StoreSceneInfo.GetOldInformation();
        // ChairController.LoadOldInfo(storeSceneInfo.chairs);
    }

    private bool IsNeedToLoadSceneAgain()
    {
        return StoreSceneInfo.hasChangedSceneAtLeastOneTime;
    }

}
