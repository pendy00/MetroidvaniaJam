using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMenu : MonoBehaviour
{
    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;
    private PlayerAttributesController player_attributes_controller;
    private CollectableItemController collectable_item_controller;

    private bool active_tab;
    private int index;

    public bool Active_tab { get => active_tab; set => active_tab = value; }
    public int Indec { get => index; set => index = value; }

    public void Init(PlayerInputController player_input_controller, InventoryController inventory_controller,
                        PlayerAttributesController player_attributes_controller, CollectableItemController collectable_item_controller)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;
        this.player_attributes_controller = player_attributes_controller;
        this.collectable_item_controller = collectable_item_controller;
    }

    public void Update()
    {
        if (active_tab && inventory_controller.Inventory.Item_count > 0)
        {
            if (player_input_controller.Player_input.Action)
            {
                collectable_item_controller.UseItem(inventory_controller.Inventory.Items[index]);
                inventory_controller.RemoveItem(inventory_controller.Inventory.Items[index], 1);
                index = 0;
            }

            if (player_input_controller.Player_input.Down)
                ChangeIndexValue(+1);

            if (player_input_controller.Player_input.Up)
                ChangeIndexValue(-1);
        }
    }

    public void ChangeIndexValue(int value)
    {
        index += value;
        if(index < 0)
            index = 0;
        if (index >= inventory_controller.Inventory.Item_count)
            index = inventory_controller.Inventory.Item_count - 1;

        inventory_controller.UpdateCursorUI(index);
    }
}