using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manage player's inventory menu tab
public class PlayerInventoryMenu : MonoBehaviour
{
    private PlayerInputController player_input_controller; // get the player input
    private PlayerInventoryController inventory_controller;
    private CollectableItemController collectable_item_controller;

    private bool active_tab; // check if this tab is active
    private int index; // index for item selection

    public bool Active_tab { get => active_tab; set => active_tab = value; }
    public int Index { get => index; set => index = value; }
    public PlayerInventoryController Inventory_controller { get => inventory_controller; set => inventory_controller = value; }

    public void Init(PlayerInputController player_input_controller, PlayerInventoryController inventory_controller, 
                        CollectableItemController collectable_item_controller)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;
        this.collectable_item_controller = collectable_item_controller;
    }

    public void Update()
    {
        // if there are items in the inventory allow scrolling through them
        if (active_tab && inventory_controller.Inventory.Item_count > 0)
        {
            // use selected item
            if (player_input_controller.Player_input.Action)
                collectable_item_controller.UseItem(inventory_controller.Inventory.Items[index]);

            //check for other input to discard item ecc.

            // navigates through items
            if (player_input_controller.Player_input.Down_single_press)
                ChangeIndexValue(+1);

            if (player_input_controller.Player_input.Up_single_press)
                ChangeIndexValue(-1);
        }
    }

    // check for item list boundaries
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