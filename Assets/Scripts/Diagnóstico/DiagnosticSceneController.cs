using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosticSceneController : MonoBehaviour
{
    static DiagnosticSceneController singleton;
    static PlayerDiagnosticInfo playerDiagnosticInfo;
    int dialogNumber=0;
    public static DiagnosticState diagnosticState;

    private void Awake()
    {
        singleton = this;
    }

    public void Start()
    {
        LoadPlayerInformantionAndShowDialog();
    }

    static void LoadPlayerInformantionAndShowDialog()
    {
        LoadPlayerInfo(DiagnosticSceneInformation.playerDiagnosticInfo);
        SetStatusToShowingDialog();
    }

    private static void SetStatusToShowingDialog()
    {
        diagnosticState = DiagnosticState.ShowingDialog;
    }

    private void Update()
    {
        if (IsShowingDialog())
        {
            if (IsLeftMouseButtonDown())
            {
                if (ThereIsDialogToShow())
                {
                    ShowNextDialog();
                    dialogNumber++;
                }
                else
                {
                    SetStateToPlaying();
                }
            }
        }
    }

    private void SetStateToPlaying()
    {
        diagnosticState = DiagnosticState.Playing;
    }

    private void ShowNextDialog()
    {
        DialogPanelController.SetTextAnimated(playerDiagnosticInfo.preDialogForTheWitcher[dialogNumber]);
    }

    private bool ThereIsDialogToShow()
    {
        return playerDiagnosticInfo.preDialogForTheWitcher.Count > dialogNumber;
    }

    private bool IsShowingDialog()
    {
        return diagnosticState == DiagnosticState.ShowingDialog;
    }

    private static void LoadPlayerInfo(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        DiagnosticSceneController.playerDiagnosticInfo = playerDiagnosticInfo;
        LoadBody(playerDiagnosticInfo);
    }

    private static void LoadBody(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        PlayerDiagnosticController.LoadAllBodyParts(playerDiagnosticInfo);
    }

    private static void LoadLeg(BodyInformation leg)
    {
    }

    private static void LoadArm(BodyInformation arm)
    {
    }

    private static void LoadTorso(BodyInformation torso)
    {
    }

    private static void LoadHead(BodyInformation head)
    {
        
    }

    public static PlayerDiagnosticInfo GetPlayerDiagnosticInfo()
    {
        return playerDiagnosticInfo;
    }

    private bool IsLeftMouseButtonDown()
    {
        int LEFT_MOUSE_BUTTON = 0;
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON);
    }

    public enum DiagnosticState
    {
        ShowingDialog,
        Playing
    }
}
