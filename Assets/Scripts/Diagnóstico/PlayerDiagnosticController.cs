using System;
using UnityEngine;

public class PlayerDiagnosticController : MonoBehaviour
{
    public BodyPart head;
    public BodyPart torso;
    public BodyPart arms;
    public BodyPart legs;
    public PlayerDiagnosticInfo info;
    static PlayerDiagnosticController singleton;

    private void Awake()
    {
        singleton = this;
    }

    public static void LoadAllBodyParts(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        singleton.info = playerDiagnosticInfo;
        LoadHead(playerDiagnosticInfo.head);
        LoadTorso(playerDiagnosticInfo.torso);
        LoadArm(playerDiagnosticInfo.arm);
        LoadLegs(playerDiagnosticInfo.leg);
    }

    public static bool IsInfoEquals(BodyPartOrigin info)
    {
        return singleton.info.whoAmI == info;
    }

    private static void LoadLegs(BodyInformation leg)
    {
        singleton.legs.LoadClickableInformation(leg);
        singleton.legs.LoadArt(leg);
    }

    private static void LoadArm(BodyInformation arm)
    {
        singleton.arms.LoadClickableInformation(arm);
        singleton.arms.LoadArt(arm);
    }

    private static void LoadTorso(BodyInformation torso)
    {
        singleton.torso.LoadClickableInformation(torso);
        singleton.torso.LoadArt(torso);
    }

    private static void LoadHead(BodyInformation head)
    {
        singleton.head.LoadClickableInformation(head);
        singleton.head.LoadArt(head);
    }
}
