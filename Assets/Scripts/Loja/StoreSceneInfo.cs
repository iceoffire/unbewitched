using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSceneInfo : MonoBehaviour
{
    static List<Chair> chairsInfo;
    public static PlayerDiagnosticInfo lastPlayerDiagnosticInfo;
    public static bool hasChangedSceneAtLeastOneTime = false;

    public static List<PlayerDiagnosticInfo> playersInfo = new List<PlayerDiagnosticInfo>();

    public static void SaveOldInformation(List<Chair> chairsInfo, PlayerDiagnosticInfo lastPlayerDiagnosticInfo)
    {
        playersInfo = new List<PlayerDiagnosticInfo>();
        StoreSceneInfo.lastPlayerDiagnosticInfo = lastPlayerDiagnosticInfo;
        foreach (Chair chair in chairsInfo.ToArray())
        {
            if (chair.playerSited != null)
                StoreSceneInfo.playersInfo.Add(chair.playerSited.playerDiagnosticInfo);
        }
        hasChangedSceneAtLeastOneTime = true;
    }

    public static StoreSceneInfo GetOldInformation()
    {
        return new StoreSceneInfo();
    }
}
