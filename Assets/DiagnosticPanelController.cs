using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DiagnosticPanelController : MonoBehaviour
{
    public RectTransform panelPlayer;
    public RectTransform panelDialog;

    static DiagnosticPanelController singleton;
    Vector3 playerHidePosition;
    Vector3 playerShowPosition;
    Vector3 dialogHidePosition;
    Vector3 dialogShowPosition;

    void Awake()
    {
        singleton = this;
        LoadPlayerPositions();
        LoadDialogPositions();
    }

    public static void Show()
    {
        ShowPlayer();
        ShowDialog();
    }

    public static void Hide()
    {
        HidePlayer();
        HideDialog();
    }

    private static void HideDialog()
    {
        singleton.panelDialog.DOLocalMove(singleton.dialogHidePosition, 0.5f);
    }

    private static void HidePlayer()
    {
        singleton.panelPlayer.DOLocalMove(singleton.playerHidePosition, 0.5f);
    }

    private static void ShowDialog()
    {
        singleton.panelDialog.DOLocalMove(singleton.dialogShowPosition, 0.5f);
    }

    private static void ShowPlayer()
    {
        singleton.panelPlayer.DOLocalMove(singleton.playerShowPosition, 0.5f);
    }

    private void LoadDialogPositions()
    {
        dialogShowPosition = panelDialog.localPosition;
        dialogHidePosition = panelDialog.localPosition + new Vector3(0,-200);
    }

    private void LoadPlayerPositions()
    {
        playerShowPosition = panelPlayer.localPosition;
        playerHidePosition = panelPlayer.localPosition + new Vector3(500, 0);
    }
}
