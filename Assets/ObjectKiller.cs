using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ingrediente")
        {
            IngredientesController.SpawnNewItem(collision.GetComponent<Item>());
        }
        Destroy(collision.gameObject);
    }
}
