using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public BodyPartOrigin origin;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(() => { DiagnosticControl.GoToDiagnostics(origin); });
    }
}
