using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ingrediente")
        {
            IngredientesController.SpawnNewItem(other.GetComponent<Item>());
        }
        Destroy(other.gameObject);
    }
}
