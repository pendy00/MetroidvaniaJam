using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;
    private PlayerAttributesController player_attributes_controller;
    private PlayerInvenoryMenu player_inventory_menu;

    private int index;
    private bool is_open;

    public void Init(PlayerInputController player_input_controller, InventoryController inventory_controller,
                        PlayerAttributesController player_attributes_controller, PlayerInvenoryMenu player_inventory_menu)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;
        this.player_attributes_controller = player_attributes_controller;
        this.player_inventory_menu = player_inventory_menu;
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Menu)
            OpenMenu();

        if(player_input_controller.Player_input.Cancel)
            CloseMenu();

        if (is_open && player_input_controller.Player_input.Right)
            ChangeActiveTab(+1);

        if (is_open && player_input_controller.Player_input.Left)
            ChangeActiveTab(-1);
    }

    public void OpenMenu()
    {
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.MENU);
        ShowActiveTab(true);
        is_open = true;
    }

    public void CloseMenu()
    {
        index = 0;
        is_open = false;
        ShowActiveTab(false);
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
    }

    public void ChangeActiveTab(int value)
    {
        index += value;
        if (index < 0)
            index = 0;

        if (index > 1)
            index = 1;

        ShowActiveTab(true);
    }

    public void ShowActiveTab(bool value)
    {
        switch (index)
        {
            case 0:
                player_attributes_controller.ShowAttributesUI(value);
                inventory_controller.ShowInventory(false);
                player_inventory_menu.Active_tab = false;
                break;
            case 1:
                inventory_controller.ShowInventory(value);
                player_inventory_menu.Active_tab = value;
                player_attributes_controller.ShowAttributesUI(false);
                break;
            default:
                break;
        }
    }
}