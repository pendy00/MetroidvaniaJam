using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemController : MonoBehaviour
{
    private PlayerAttributesController player_attributes_controller;

    public void UseItem(Collectable item)
    {
        switch (item.item_name)
        {
            case "medics":
                player_attributes_controller.UpdateLifePoint(((Medics) item).healing_power);
                break;
            default:
                break;
        }
    }
}