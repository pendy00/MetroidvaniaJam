using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    private Transform player_position;
    private PlayerAttributes player_attributes;
    private PlayerInventory player_inventory;
    private PlayerEquipment player_equipment;

    public void LoadPlayerData(string file_name)
    {
        player_position = FindObjectOfType<PlayerMovementsController>().gameObject.transform;
        player_attributes = FindObjectOfType<PlayerAttributesController>().Player_attributes;
        player_inventory = FindObjectOfType<PlayerInventory>();
        player_equipment = FindObjectOfType<PlayerEquipment>();

        SaveLoad.Load.LoadData(file_name, player_position, player_inventory, player_equipment);
    }
}