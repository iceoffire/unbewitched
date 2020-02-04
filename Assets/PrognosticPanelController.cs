using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PrognosticPanelController : MonoBehaviour
{
    public RectTransform panelCauldron;
    public RectTransform panelIngredients;
    public RectTransform panelPotion;
    public GameObject buttonCallDiagnostic;

    Vector3 cauldronShowPosition;
    Vector3 cauldronHidePosition;
    Vector3 ingredientsShowPosition;
    Vector3 ingredientsHidePosition;

    static PrognosticPanelController singleton;

    void Awake()
    {
        singleton = this;
        LoadCauldronPositions();
        LoadIngredientsPositions();
    }

    private void LoadIngredientsPositions()
    {
        ingredientsHidePosition = panelIngredients.localPosition;
        ingredientsShowPosition = panelIngredients.localPosition + new Vector3(0,210);
    }

    private void LoadCauldronPositions()
    {
        cauldronHidePosition = panelCauldron.localPosition;
        cauldronShowPosition = panelCauldron.localPosition + new Vector3(400,0);
    }

    public static void Show()
    {
        ShowCauldron();
        ShowIngredients();
        singleton.buttonCallDiagnostic.SetActive(true);
    }

    public static void Hide()
    {
        HideCauldron();
        HideIngredients();
        singleton.buttonCallDiagnostic.SetActive(false);
    }

    static void ShowCauldron()
    {
        singleton.panelCauldron.transform.DOLocalMove(singleton.cauldronShowPosition, 0.5f);
    }

    static void ShowIngredients()
    {
        singleton.panelIngredients.DOLocalMove(singleton.ingredientsShowPosition, 0.5f);
    }

    static void HideCauldron()
    {
        singleton.panelCauldron.DOLocalMove(singleton.cauldronHidePosition, 0.5f);
    }

    static void HideIngredients()
    {
        singleton.panelIngredients.DOLocalMove(singleton.ingredientsHidePosition, 0.5f);
    }
    
}
