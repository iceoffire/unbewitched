using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TDDDiagnostico : MonoBehaviour
{
    public PlayerDiagnosticInfo playerDiagnosticInfo;
    private void Awake()
    {
        DiagnosticSceneInformation.playerDiagnosticInfo = playerDiagnosticInfo;
    }
}
