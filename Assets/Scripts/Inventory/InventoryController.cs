using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Inventory inventory;
    private InventoryUI inventory_ui;
    private ItemLibrary item_library;

    public int bandage_max_quantity;
    public int medicine_max_quantity;

    public Inventory Inventory { get =>inventory; set => inventory = value; }

    public void Init(Inventory inventory, InventoryUI inventory_ui, ItemLibrary item_library)
    {
        this.inventory = inventory;
        this.inventory_ui = inventory_ui;
        this.item_library = item_library;
    }

    public void AddItem(Collectable item)
    {
        inventory.AddItemQuantity(item, GetMaxQuantity(item));
    }

    public void RemoveItem(Collectable item, int quantity)
    {
        inventory.RemoveItemQuantity(item, quantity);
        inventory_ui.UpdateUI(inventory.Items, item_library);
    }

    public int GetMaxQuantity(Collectable item)
    {
        if (item.Item_name == item_library.Bandage)
            return bandage_max_quantity;

        if (item.Item_name == item_library.Medicine)
            return medicine_max_quantity;

        return 0;
    }

    public void ShowInventory(bool value)
    {
        if (value)
            inventory_ui.UpdateUI(inventory.Items, item_library);
        else
            inventory_ui.RemoveAllItem();

        inventory_ui.ShowInventoryUI(value);
    }
}