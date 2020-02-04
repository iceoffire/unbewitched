using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caldeirao : MonoBehaviour
{
    public Collider2D collider;
    public Rigidbody2D rigidbody2D;
    List<TypeItem> itensInside = new List<TypeItem>();
    static Caldeirao singleton;
    BodyPartOrigin potionBody = default;

    void Awake()
    {
        singleton = this;
    }

    public static void RemoveAllItens()
    {
        singleton.itensInside = new List<TypeItem>();
    }

    Dictionary<string, BodyPartOrigin> itens = new Dictionary<string, BodyPartOrigin>
    {
       { "flower|phoenixfather", BodyPartOrigin.Human},
       { "ogretooth|earrabbit", BodyPartOrigin.Horse},
       { "mush|eye", BodyPartOrigin.Frog},
       { "batwing|tentacle", BodyPartOrigin.Cthulhu},
       { "phoenixfather|flower", BodyPartOrigin.Human},
       { "earrabbit|ogretooth", BodyPartOrigin.Horse},
       { "eye|mush", BodyPartOrigin.Frog},
       { "tentacle|batwing", BodyPartOrigin.Cthulhu},
    };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ingrediente")
        {
            if (itensInside.Count >= 2) return;
            Item item = collision.gameObject.GetComponent<Item>();
            itensInside.Add(item.type);
            IngredientesController.SpawnNewItem(item);
            PotionPanelController.SpawnItem(item);
            Destroy(item.gameObject);
            OnItemEnter();
        }
    }

    private void OnItemEnter()
    {
        string textToCompare = string.Empty;
        foreach(TypeItem typeItem in itensInside)
        {
            if (textToCompare != string.Empty)
            {
                textToCompare += "|";
            }
            textToCompare += typeItem.ToString();
        }
        if (itens.ContainsKey(textToCompare))
        {
            potionBody = itens[textToCompare];

            ButtonsPotionPanelController.EnableOkButton();
        }
    }

    public void GeneratePotionAndSendToThePlayer()
    {
        if (potionBody == default) return;
        BodyPartOrigin body = potionBody;
        if (PlayerDiagnosticController.IsInfoEquals(body))
        {
            StoreSceneInfo.win = true;
        }
        else
        {
            StoreSceneInfo.win = false;
        }
        SceneManager.LoadScene("Store");
    }
}
