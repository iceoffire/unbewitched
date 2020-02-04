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
        ChangeGameToDiagnostic();
        LoadPlayerInformantionAndShowDialog();
    }

    public void _ChangeGameToDiagnostic()
    {
        ChangeGameToDiagnostic();
    }

    public void _ChangeGameToMakingPotions()
    {
        ChangeGameToMakingPotions();
    }

    public static void ChangeGameToDiagnostic()
    {
        diagnosticState = DiagnosticState.MakingDiagnostic;
        DiagnosticPanelController.Show();
        PrognosticPanelController.Hide();
    }

    public static void ChangeGameToMakingPotions()
    {
        diagnosticState = DiagnosticState.MakingPotion;
        PrognosticPanelController.Show();
        DiagnosticPanelController.Hide();
        OptionsToolController.Hide();
    }

    static void LoadPlayerInformantionAndShowDialog()
    {
        LoadPlayerInfo(DiagnosticSceneInformation.playerDiagnosticInfo);
        ChangeGameToDiagnostic();
    }

    private void Update()
    {
        if (IsMakingDiagnostic())
        {
            if (IsLeftMouseButtonDown())
            {
                if (ThereIsDialogToShow())
                {
                    ShowNextDialog();
                    dialogNumber++;
                }
                if (!ThereIsDialogToShow())
                {
                    SetStateToPlaying();
                }
            }
        }
    }

    private void SetStateToPlaying()
    {
        diagnosticState = DiagnosticState.MakingDiagnostic;
    }

    private void ShowNextDialog()
    {
        DialogPanelController.SetTextAnimated(playerDiagnosticInfo.preDialogForTheWitcher[dialogNumber]);
    }

    public static bool ThereIsDialogToShow()
    {
        return playerDiagnosticInfo.preDialogForTheWitcher.Count > singleton.dialogNumber;
    }

    private bool IsMakingDiagnostic()
    {
        return diagnosticState == DiagnosticState.MakingDiagnostic;
    }

    private static void LoadPlayerInfo(PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        DiagnosticSceneController.playerDiagnosticInfo = playerDiagnosticInfo;
        LoadBody(playerDiagnosticInfo);
        singleton.ShowNextDialog();
        singleton.dialogNumber++;
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

}
public enum DiagnosticState
{
    MakingDiagnostic,
    MakingPotion
}
