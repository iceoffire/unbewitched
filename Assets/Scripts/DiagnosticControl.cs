using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiagnosticControl : MonoBehaviour
{    
    public static void GoToDiagnostics(BodyPartOrigin monsterType)
    {
        if (monsterType >= 0) DiagnosticSceneInformation.monsterType = monsterType;
        SceneManager.LoadScene(2); //Scene 2 is Diagnostics
    }
}
