using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaldeiraoController : MonoBehaviour
{
    public Button button;
    void Awake()
    {
        button.onClick.AddListener(() => { DiagnosticSceneController.ChangeGameToMakingPotions(); });
    }
}
