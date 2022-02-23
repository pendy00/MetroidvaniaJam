using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    private PlayerEquipment player_equipment;
    private PlayerEquipmentUI player_equipment_ui;

    public void Init(PlayerEquipment player_equipment, PlayerEquipmentUI player_equipment_ui)
    {
        this.player_equipment = player_equipment;
        this.player_equipment_ui = player_equipment_ui;
    }

    public Equipable EquipItem(Equipable item)
    {
        return player_equipment.Equip(item);
    }

    public Equipable UnequipItem(Equipable item)
    {
        return player_equipment.Unequip(item);
    }

    public void ShowEquipment(bool value)
    {
        player_equipment_ui.ShowInventoryUI(value);   
    }
}