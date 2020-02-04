using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPotionPanelController : MonoBehaviour
{
    static ButtonsPotionPanelController singleton;
    public Button okButton;

    void Awake()
    {
        singleton = this;
    }

    public static void EnableOkButton()
    {
        singleton.okButton.interactable = true;
    }

    public static void DisableOkButton()
    {
        singleton.okButton.interactable = false;
    }
}
