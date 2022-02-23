using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// load and init all the inventory's required script to work properly
public class InventoryScriptsLoader : MonoBehaviour
{
    private PlayerInventory inventory;
    private PlayerInventoryUI inventory_ui;
    private PlayerInventoryController inventory_controller;

    private ItemLibrary item_library;

    // find and load scripts
    public void LoadInventory()
    {
        inventory = ScriptsLoader.LoadScript<PlayerInventory>();
        inventory_ui = ScriptsLoader.LoadScript<PlayerInventoryUI>();
        inventory_controller = ScriptsLoader.LoadScript<PlayerInventoryController>();
        item_library = ScriptsLoader.LoadScript<ItemLibrary>();

        InitInventory();
    }

    // initialize and connect scripts
    public void InitInventory()
    {
        inventory_controller.Init(inventory, inventory_ui, item_library);
    }
}