using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bridge between items and invetory it manage different item in the proper way
public class CollectableItemController : MonoBehaviour
{
    private ItemLibrary item_library;
    private PlayerAttributesController player_attributes_controller;
    private PlayerEquipmentController player_equipment_controller;
    private PlayerInventoryController player_inventory_controller;

    public void Init(PlayerAttributesController player_attributes_controller, ItemLibrary item_library, 
                        PlayerInventoryController player_inventory_controller, PlayerEquipmentController player_equipment_controller)
    {
        this.player_attributes_controller = player_attributes_controller;
        this.item_library = item_library;
        this.player_equipment_controller = player_equipment_controller;
        this.player_inventory_controller = player_inventory_controller;
    }

    // manage item usage
    public void UseItem(GameItem item)
    {
        switch (item.Item_name)
        {
            case ItemLibrary.bandage:
                player_attributes_controller.UpdateLifePoint(+item_library.Bandage_healing_power);
                player_inventory_controller.RemoveItemSingleQuantity(item);
                break;
            case ItemLibrary.medicine:
                player_attributes_controller.UpdateLifePoint(+item_library.Medicine_healing_power);
                player_inventory_controller.RemoveItemSingleQuantity(item);
                break;
            case ItemLibrary.whip:
                Equipable weapon = (Equipable)item;
                EquipItem(weapon);
                InstantiateWeapon(weapon);
                break;
            default:
                break;
        }
    }

    // manage equipment
    public void EquipItem(Equipable e)
    {
        Equipable temp = player_equipment_controller.EquipItem(e);

        if (temp != null)
        {
            player_attributes_controller.UpdateLifePoint(-temp.Life_points);
            player_attributes_controller.UpdateStats(-temp.Strenght, -temp.Constitution, -temp.Intelligence, -temp.Luck);
            player_inventory_controller.AddItemKeepQuantity(temp);
            item_library.DestroyItem(temp.Item_name);
        }

        player_attributes_controller.UpdateLifePoint(e.Life_points);
        player_attributes_controller.UpdateStats(e.Strenght, e.Constitution, e.Intelligence, e.Luck);

        player_inventory_controller.RemoveItemKeepQuantity(e);
    }

    // instantiate weapon from prefab
    public void InstantiateWeapon(Equipable e)
    {
        GameObject player = FindObjectOfType<PlayerMovementsController>().gameObject;
        GameObject go = item_library.GetItemPrefab(e.Item_name);
        EquipableUI eui = go.GetComponent<EquipableUI>();
        eui.Game_item = new Equipable(e.Level_required, e.Life_points, e.Strenght, e.Constitution, e.Intelligence, e.Luck);
        eui.Game_item.Item_name = e.Item_name;
        eui.Game_item.Item_quantity = e.Item_quantity;
        GameObject inst = Instantiate(go);

        // TODO set proper weapon positioning
        inst.transform.SetParent(player.transform);
        inst.transform.localPosition = Vector3.zero;
    }

    // manage equipment
    public void UnequipItem(Equipable e)
    {
        Equipable temp = player_equipment_controller.UnequipItem(e);

        if(temp != null)
        {
            player_attributes_controller.UpdateLifePoint(-e.Life_points);
            player_attributes_controller.UpdateStats(-e.Strenght, -e.Constitution, -e.Intelligence, -e.Luck);
            player_inventory_controller.AddItemKeepQuantity(e);
            item_library.DestroyItem(e.Item_name);
        }
        
    }
}