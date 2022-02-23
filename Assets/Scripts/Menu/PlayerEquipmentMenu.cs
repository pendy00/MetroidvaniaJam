using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manage player's equipment menu tab
public class PlayerEquipmentMenu : MonoBehaviour
{
    private PlayerInputController player_input_controller; // get player's input
    private PlayerEquipmentController player_equipment_controller;

    private bool active_tab; // check if this tab is active

    public bool Active_tab { get => active_tab; set => active_tab = value; }
    public PlayerEquipmentController Equipment_controller { get => player_equipment_controller; set => player_equipment_controller = value; }

    public void Init(PlayerInputController player_input_controller, PlayerEquipmentController player_equipment_controller)
    {
        this.player_input_controller = player_input_controller;
        this.player_equipment_controller = player_equipment_controller;
    }

    // TODO implement navigation through equipment and item utilization similiar to the inventory
}