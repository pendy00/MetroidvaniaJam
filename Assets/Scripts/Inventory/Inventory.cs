using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Collectable> inventory_items;

    public List<Collectable> Inventory_items { get => inventory_items; set => inventory_items = value; }

    public int ItemCount { get => inventory_items.Count; }

    private void Awake()
    {
        inventory_items = new List<Collectable>();
    }

    public void AddItem(Collectable item)
    {
        bool added = false;

        foreach(Collectable c in inventory_items)
        {
            if (c.item_name == item.item_name)
            {
                c.AddQuantity(item.item_quantity);
                added = true;
                break;
            }
        }
        
        if(!added)
        {
            inventory_items.Add(item.GetComponent<Collectable>());
        }
    }

    public void RemoveItem(Collectable item)
    {
        Collectable temp = null;

        foreach (Collectable c in inventory_items)
        {
            if (c.item_name == item.item_name)
            {
                c.AddQuantity(-item.item_quantity);
                temp = c;
                break;
            }
        }

        if (temp && temp.item_quantity <= 0)
                inventory_items.Remove(temp);
    }
}