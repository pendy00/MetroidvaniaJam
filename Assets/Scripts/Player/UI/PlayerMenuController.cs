using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    private bool menu_open;
    private int tab_index;
    public int menu_tabs;
    private PlayerInputController player_input_controller;
    private PlayerAttributesController player_attributes_controller; //informations for stats tab
    private PlayerInventoryController player_inventory_controller; //informations and interactions for inventory tab
    //informations for equipped items tam
    //informations for hospital status tab

    public void Init(PlayerInputController player_input_controller, PlayerAttributesController player_attributes_controller)
    {
        this.player_input_controller = player_input_controller;
        this.player_attributes_controller = player_attributes_controller;

        tab_index = 0;
    }

    private void Awake()
    {
        player_input_controller = FindObjectOfType<PlayerInputController>();
        player_inventory_controller = FindObjectOfType<PlayerInventoryController>();
    }
    private void Update()
    {
        if (player_input_controller.Player_input.Menu)
            OpenMenu();

        if (player_input_controller.Player_input.Cancel)
            CloseMenu();

        if (menu_open)
        {
            if (player_input_controller.Player_input.Right)
                ChangeMenuTab(+1);

            if (player_input_controller.Player_input.Left)
                ChangeMenuTab(-1);
        }
    }

    public void ChangeMenuTab(int value)
    {
        tab_index += value;
        if (tab_index < 0)
            tab_index = 0;

        if (tab_index > menu_tabs)
            tab_index = menu_tabs;

        switch (tab_index)
        {
            case 0: //scheda situazione ospedale
                break;
            case 1:
                break;
            default:
                break;
        }
    }

    public void OpenMenu()
    {
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.MENU);
        menu_open = true;
        player_inventory_controller.OpenInventoryTab();
        //player_stats_controller.ShowStatsCard(true);
    }

    public void CloseMenu()
    {
        //hide menu
        tab_index = 0;
        menu_open = false;
        player_inventory_controller.CloseInventoryTab();
        //player_stats_controller.ShowStatsCard(false);
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
    }

    public void ActivateMenuTab(bool value)
    {

    }
}