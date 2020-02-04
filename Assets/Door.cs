using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public RectTransform door;
    static Door singleton;

    void Awake()
    {
        singleton = this;
    }
    
    public static void Open()
    {
        singleton.door.DORotate(new Vector3(0,0,0),.4f);
    }

    public static void Close()
    {
        singleton.door.DORotate(new Vector3(0,-90,0),.4f);
    }
}
