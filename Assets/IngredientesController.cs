using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientesController : MonoBehaviour
{
    List<ItemInfo> itensPadroes = new List<ItemInfo>();
    static IngredientesController singleton;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        foreach(Item item in transform.GetComponentsInChildren<Item>())
        {
            itensPadroes.Add(new ItemInfo(item));
        }
    }

    public static void SpawnNewItem(Item item)
    {
        Item newItem = Instantiate(item.gameObject, singleton.gameObject.transform).GetComponent<Item>();
        newItem.transform.localPosition = item.initialLocalPosition;
        newItem.ResetPanelPosition();
        newItem.ResetRigidbody();
    }
}
