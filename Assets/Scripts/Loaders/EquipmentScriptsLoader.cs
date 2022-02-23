using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// load and init all the equipment's required script to work properly
public class EquipmentScriptsLoader : MonoBehaviour
{
    private PlayerEquipment player_equipment;
    private PlayerEquipmentUI player_equipment_ui;
    private PlayerEquipmentController player_equipment_controller;

    // find and load player scripts
    public void LoadEquipment()
    {
        player_equipment = ScriptsLoader.LoadScript<PlayerEquipment>();
        player_equipment_ui = ScriptsLoader.LoadScript<PlayerEquipmentUI>();

        player_equipment_controller = ScriptsLoader.LoadScript<PlayerEquipmentController>();

        InitEquipment();
    }

    // initialize and connect scripts
    public void InitEquipment()
    {
        player_equipment_controller.Init(player_equipment, player_equipment_ui);
    }
    
}