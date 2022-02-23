using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    private Transform player_position;
    private PlayerAttributes player_attributes;
    private PlayerInventory player_inventory;
    private PlayerEquipment player_equipment;

    public void SavePlayerData(string file_name)
    {
        player_position = FindObjectOfType<PlayerMovementsController>().gameObject.transform;
        player_attributes = FindObjectOfType<PlayerAttributesController>().Player_attributes;
        player_inventory = FindObjectOfType<PlayerInventory>();
        player_equipment = FindObjectOfType<PlayerEquipment>();

        SaveLoad.Save.SaveData(file_name, player_position, player_inventory, player_equipment);
        //save.SaveData(player_attributes);
    }
}