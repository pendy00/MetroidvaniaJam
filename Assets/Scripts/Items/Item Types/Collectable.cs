using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private Sprite sprite;
    public string item_name;
    public int item_quantity;
    public int max_quantity;

    public Sprite Sprite { get => sprite; set => sprite = value; }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public int AddQuantity(int value)
    {
        item_quantity += value;

        if (item_quantity > max_quantity)
            item_quantity = max_quantity;

        return item_quantity;
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}