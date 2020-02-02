using UnityEngine;

public class ItemInfo
{
    public Sprite sprite;
    public Vector3 initialPosition;
    public ItemInfo(Item item)
    {
        this.sprite = item.sprite;
        this.initialPosition = item.initialLocalPosition;
    }
}