using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemController : MonoBehaviour
{
    private PlayerAttributesController player_attributes_controller;
    private ItemLibrary item_library;

    public void Init(PlayerAttributesController player_attributes_controller, ItemLibrary item_library)
    {
        this.player_attributes_controller = player_attributes_controller;
        this.item_library = item_library;
    }

    public void UseItem(Collectable item)
    {
        switch (item.Item_name)
        {
            case "bandage":
                player_attributes_controller.UpdateLifePoint(+item_library.Bandage_healing_power);
                break;
            case "medicine":
                player_attributes_controller.UpdateLifePoint(+item_library.Medicine_healing_power);
                break;
            default:
                break;
        }
    }
}