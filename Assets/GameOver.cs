using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static int customers = 0;
    public GameObject results;

    public void Plus()
    {
        customers++;
    }

    private void Update()
    {
        if (customers >= 3 && !results.activeInHierarchy)
        {
            results.SetActive(true);
        }
    }
}
