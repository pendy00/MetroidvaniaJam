using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private PlayerInventory inventory;
    private PlayerInventoryUI inventory_ui;
    private ItemLibrary item_library;

    public int bandage_max_quantity;
    public int medicine_max_quantity;

    public PlayerInventory Inventory { get =>inventory; set => inventory = value; }

    public void Init(PlayerInventory inventory, PlayerInventoryUI inventory_ui, ItemLibrary item_library)
    {
        this.inventory = inventory;
        this.inventory_ui = inventory_ui;
        this.item_library = item_library;
    }

    public void AddItem(GameItem value)
    {
        GameItem item = inventory.FindItem(value);
        if (item != null)
        {
            int temp = GetMaxQuantity(value);
            item.Item_quantity += value.Item_quantity;
            if (item.Item_quantity > temp)
                item.Item_quantity = temp;
        }
        else
        {
            inventory.AddItem(value);
        }

        inventory_ui.UpdateUI(inventory.Items, item_library);
    }

    public void AddItemKeepQuantity(GameItem value)
    {
        GameItem item = inventory.FindItem(value);
        if (item != null)
            this.AddItem(value);
        else
            inventory.AddItem(value);

        inventory_ui.UpdateUI(inventory.Items, item_library);
    }

    public void RemoveItem(GameItem value)
    {
        GameItem item = inventory.FindItem(value);
        if (item != null)
        {
            item.Item_quantity -= value.Item_quantity;
            if (item.Item_quantity <= 0)
                inventory.RemoveItem(item);

            inventory_ui.UpdateUI(inventory.Items, item_library);
        }
    }

    public void RemoveItemKeepQuantity(GameItem value)
    {
        GameItem item = inventory.FindItem(value);
        if (item != null)
        {
            inventory.RemoveItem(item);

            inventory_ui.UpdateUI(inventory.Items, item_library);
        }
    }

    public void RemoveItemSingleQuantity(GameItem value)
    {
        GameItem item = inventory.FindItem(value);
        if (item != null)
        {
            item.Item_quantity -= 1;
            if (item.Item_quantity <= 0)
                inventory.RemoveItem(item);

            inventory_ui.UpdateUI(inventory.Items, item_library);
        }
    }

    public int GetMaxQuantity(GameItem value)
    {
        switch (value.Item_name)
        {
            case ItemLibrary.bandage:
                return bandage_max_quantity;
            case ItemLibrary.medicine:
                return medicine_max_quantity;
            default:
                return 0;
        }
    }

    public void ShowInventory(bool value)
    {
        if (value)
            inventory_ui.UpdateUI(inventory.Items, item_library);
        else
            inventory_ui.RemoveAllItem();

        inventory_ui.ShowInventoryUI(value);
    }

    public void UpdateCursorUI(int index)
    {
        inventory_ui.UpdateCursorPosition(index);
    }
}