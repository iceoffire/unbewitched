using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class OptionsToolButtonController : MonoBehaviour
{
    public OptionType optionType;
    [HideInInspector]
    public Vector2 maximumSize;
    
    public static float timeToShowAnimate = 0.4f;
    Vector2 minimumSize = new Vector2(0, 0);
    RectTransform rectTransform;
    Button button;

    private void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
        maximumSize = rectTransform.sizeDelta;
        maximumSize.x = this.transform.parent.GetComponent<RectTransform>().sizeDelta.x; // gambissssssssssss
        button = this.GetComponent<Button>();
    }

    public void Start()
    {
        button.onClick.AddListener(() => { OnClick(); });
    }

    void OnClick()
    {
        ShowText();
        HideOptionsTool();
    }

    private void HideOptionsTool()
    {
        OptionsToolController.Hide();
    }

    private void ShowText()
    {
        string textToShow = OptionsToolController.GetTextFromOptionType(this.optionType);
        DialogPanelController.SetTextAnimated(textToShow);
    }

    public void AnimateOnShow()
    {
        SetSizeDeltaToMinimum();
        MakeAnimationToMaximumSize();
    }

    private void MakeAnimationToMaximumSize()
    {
        rectTransform.DOSizeDelta(maximumSize, timeToShowAnimate);
    }

    public void SetSizeDeltaToMinimum()
    {
        rectTransform.sizeDelta = minimumSize;
    }

    internal void AnimateOffShow()
    {
        SetSizeDeltaToMaximum();
        MakeAnimationToMinimumSize();
    }

    private void MakeAnimationToMinimumSize()
    {
        rectTransform.DOSizeDelta(minimumSize, timeToShowAnimate);
    }

    private void SetSizeDeltaToMaximum()
    {
        rectTransform.sizeDelta = maximumSize;
    }
}

public enum OptionType
{
    Wand,
    Examinate,
    Look
}