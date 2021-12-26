using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScriptsLoader : MonoBehaviour
{
    private Inventory inventory;
    private InventoryUI inventory_ui;
    private InventoryController inventory_controller;

    public InventoryController Inventory_controller { get => inventory_controller; }

    private bool inventory_loaded;

    public bool Inventory_loaded { get => inventory_loaded; set => inventory_loaded = value; }

    public void LoadInventory()
    {
        inventory = ScriptsLoader.LoadScript<Inventory>();
        inventory_ui = ScriptsLoader.LoadScript<InventoryUI>();
        inventory_controller = ScriptsLoader.LoadScript<InventoryController>();

        InitInventory();
    }

    public void InitInventory()
    {
        inventory_controller.Init(inventory, inventory_ui);
    }
}