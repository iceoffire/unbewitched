using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caldeirao : MonoBehaviour
{
    public Collider2D collider;
    public Rigidbody2D rigidbody2D;
    List<TypeItem> itensInside = new List<TypeItem>();

    Dictionary<BodyPartOrigin, List<string>> itens = new Dictionary<BodyPartOrigin, List<string>>
    {
       // { BodyPartOrigin.Human, new List<TypeItem>() { } };
    };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ingrediente")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            itensInside.Add(item.type);
            IngredientesController.SpawnNewItem(item);
            Destroy(item.gameObject);
        }
    }
}
