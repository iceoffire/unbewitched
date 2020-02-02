using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isSelected;
    Vector3 offsetMouseAndObject = new Vector3();

    private void Update()
    {
        if (IsMouseDown())
        {
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-offsetMouseAndObject;
            transform.position = new Vector3(cursorPos.x, cursorPos.y, 0);
        }
    }

    private bool IsMouseDown()
    {
        return isSelected == true;
    }

    private void OnMouseDown()
    {
        isSelected = true;
        offsetMouseAndObject = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
    }

    private void OnMouseUp()
    {
        isSelected = false;
        if (this.gameObject.tag == "ingrediente")
        {
            Item item = this.gameObject.GetComponent<Item>();
            item.Drop();
        }
    }
}
