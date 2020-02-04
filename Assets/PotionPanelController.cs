using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPanelController : MonoBehaviour
{
    public GameObject itemPreshowPrefab;
    public Transform panelItemPreshow;
    static PotionPanelController singleton;

    void Awake()
    {
        singleton = this;
    }

    public static void SpawnItem(Item itemReference)
    {
        GameObject itemPreshow = Instantiate(singleton.itemPreshowPrefab, singleton.panelItemPreshow);
        itemPreshow.GetComponent<ItemPreshow>().SetSprite(itemReference.sprite);
    }

    public void RemoveAllItem()
    {
        if (panelItemPreshow.childCount == 0) return;
        foreach(Transform transform in panelItemPreshow.transform)
        {
            Destroy(transform.gameObject);
        }
        Caldeirao.RemoveAllItens();
        ButtonsPotionPanelController.DisableOkButton();
    }
}
