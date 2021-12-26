using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private PlayerItemCollider player_item_collider;
    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;
    //private CollectableItemController collectable_item_controller;
    //private PlayerEquipmentController player_equipment_controller;

    private int index;

    private void Awake()
    {
        player_input_controller = FindObjectOfType<PlayerInputController>();
        inventory_controller = FindObjectOfType<InventoryController>();
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            //Collectable temp = inventory_controller.SelectItem(index);
            //check if item is consumable or equipable
        }

        if (player_input_controller.Player_input.Up)
        {
            ChangeSelectedItem(-1);
        }

        if (player_input_controller.Player_input.Down)
        {
            ChangeSelectedItem(+1);
        }
    }

    public void OpenInventoryTab()
    {
        index = 0;
        inventory_controller.ShowInventory(true);
    }

    public void CloseInventoryTab()
    {
        inventory_controller.ShowInventory(false);
    }

    private void ChangeSelectedItem(int value)
    {
        index += value;
        if (index < 0)
            index = 0;

        if (index > inventory_controller.Inventory.ItemCount - 1)
            index = inventory_controller.Inventory.ItemCount;
    }

    public void UseItem(Collectable item)
    {
        //collectable_item_controller.UseItem(item);
    }

    public void EquipItem(Equipable item)
    {
        //player_equipment_controller.Equip(item);
    }
}