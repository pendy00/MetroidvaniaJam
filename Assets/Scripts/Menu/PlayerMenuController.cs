using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manage the player menu
public class PlayerMenuController : MonoBehaviour
{
    private PlayerInputController player_input_controller; // gets player inputs
    private PlayerAttributesController player_attributes_controller; // show attributes
    private PlayerInventoryMenu player_inventory_menu; // show inventory
    private PlayerEquipmentMenu player_equipment_menu; // show equipment

    private int index; // define current menu's tab
    private bool is_open; // check when the menu is open

    public void Init(PlayerInputController player_input_controller, PlayerAttributesController player_attributes_controller, 
                        PlayerInventoryMenu player_inventory_menu, PlayerEquipmentMenu player_equipment_menu)
    {
        this.player_input_controller = player_input_controller;
        this.player_attributes_controller = player_attributes_controller;
        this.player_inventory_menu = player_inventory_menu;
        this.player_equipment_menu = player_equipment_menu;
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Menu)
            OpenMenu();

        if(player_input_controller.Player_input.Cancel)
            CloseMenu();

        if (is_open && player_input_controller.Player_input.Right_single_press)
            ChangeActiveTab(+1);

        if (is_open && player_input_controller.Player_input.Left_single_press)
            ChangeActiveTab(-1);
    }

    // open the menu and show the tabs
    public void OpenMenu()
    {
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.MENU);
        ShowActiveTab(true);
        is_open = true;
    }

    // close the menu and hides the tab
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

        if (index > 2)
            index = 2;

        ShowActiveTab(true);
    }

    // show active tab and disable all the others
    public void ShowActiveTab(bool value)
    {
        switch (index)
        {
            case 0:
                player_attributes_controller.ShowAttributesUI(value);
                player_inventory_menu.Active_tab = false;
                player_inventory_menu.Inventory_controller.ShowInventory(false);
                player_equipment_menu.Active_tab = false;
                player_equipment_menu.Equipment_controller.ShowEquipment(false);
                break;
            case 1:
                player_attributes_controller.ShowAttributesUI(false);
                player_inventory_menu.Active_tab = value;
                player_inventory_menu.Inventory_controller.ShowInventory(value);
                player_equipment_menu.Active_tab = false;
                player_equipment_menu.Equipment_controller.ShowEquipment(false);
                break;
            case 2:
                player_attributes_controller.ShowAttributesUI(false);
                player_inventory_menu.Active_tab = false;
                player_inventory_menu.Inventory_controller.ShowInventory(false);
                player_equipment_menu.Active_tab = value;
                player_equipment_menu.Equipment_controller.ShowEquipment(value);
                break;
            default:
                break;
        }
    }
}