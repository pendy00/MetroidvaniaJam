using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Inventory inventory;
    private InventoryUI inventory_ui;

    public Inventory Inventory { get => inventory; set => inventory = value; }

    public void Init(Inventory inventory, InventoryUI inventory_ui)
    {
        this.inventory = inventory;
        this.inventory_ui = inventory_ui;
    }

    public void AddItem(Collectable item)
    {
        inventory.AddItem(item);
    }

    public void RemoveItem(Collectable item)
    {
        inventory.RemoveItem(item);
        //remove item from ui/game
    }

    public Collectable SelectItem(int index)
    {
        return inventory.Inventory_items[index];
    }

    public void ShowInventory(bool value)
    {
        inventory_ui.ShowInventory(value);
        if (value)
        {
            foreach (Collectable c in inventory.Inventory_items)
                inventory_ui.AddItem(c);
        }
        else
        {
            inventory_ui.RemoveAllItem();
        }
    }
}