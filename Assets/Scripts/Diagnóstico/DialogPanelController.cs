using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class DialogPanelController : MonoBehaviour
{
    public TextMeshProUGUI dialogLabel;
    static DialogPanelController singleton;
    public AudioSource audioSource;

    private void Awake()
    {
        singleton = this;
    }

    public static float SetTextAnimated(string text)
    {
        if (text == null) return 0;
        singleton.dialogLabel.text = "";
        int lenghText = text.Length;
        float timeToTenLeters = 0.4f;
        float timeToOwerLenght = (timeToTenLeters / 10) * lenghText;
        singleton.StartCoroutine(_AnimateTextAndMakeSound(text, timeToOwerLenght));
        return timeToOwerLenght;
    }

    private static IEnumerator _AnimateTextAndMakeSound(string text, float timeToOwerLenght)
    {
        singleton.dialogLabel.DOText(text, timeToOwerLenght);
        singleton.audioSource.Play();
        yield return new WaitForSeconds(timeToOwerLenght);
        singleton.audioSource.Stop();
    }
}
