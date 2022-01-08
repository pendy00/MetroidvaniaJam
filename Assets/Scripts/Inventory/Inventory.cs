using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Collectable> items;

    public List<Collectable> Items { get => items; set => items = value; }
    public int Item_count { get => items.Count; }

    private void Awake()
    {
        items = new List<Collectable>();
    }

    public void AddItemQuantity(Collectable item, int max_quantity)
    {
        foreach(Collectable c in items)
        {
            if (c.Item_name == item.Item_name)
            {
                c.Item_quantity += item.Item_quantity;
                if (c.Item_quantity > max_quantity)
                    c.Item_quantity = max_quantity;
                return;
            }
        }

        items.Add(item);
    }

    public void RemoveItemQuantity(Collectable item, int quantity)
    {
        Collectable temp = null;
        foreach (Collectable c in items)
        {
            if (c.Item_name == item.Item_name)
            {
                c.Item_quantity -= quantity;
                if (c.Item_quantity <= 0)
                    temp = c;
                break;
            }
        }

        if (temp != null)
            items.Remove(temp);
    }
}