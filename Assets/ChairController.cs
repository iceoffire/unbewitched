using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    public List<Transform> chairMiddlePosition;
    static ChairController singleton;

    private void Start()
    {
        singleton = this;
    }

    public static void GetFirstPositionFree()
    {

    }
}
