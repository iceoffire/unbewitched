using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreshow : MonoBehaviour
{
    public Image image;
    
    public void SetSprite(Sprite sprite)
    {
        this.image.sprite = sprite;
    }
}
