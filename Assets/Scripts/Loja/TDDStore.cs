using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TDDStore : MonoBehaviour
{
    public PlayerDiagnosticInfo playerDiagnosticInfo;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene((int)SceneIndexes.Diagnostico);
        DiagnosticSceneInformation.LoadInformation(playerDiagnosticInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
