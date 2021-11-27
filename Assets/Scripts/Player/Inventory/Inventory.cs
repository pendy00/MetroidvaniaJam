using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameItem> inventory;
    void Start()
    {
        
    }

    public void AddItem(GameItem gi)
    {
        if(gi.Game_Item_Type.Equals(GameItem.GAME_ITEM_TYPE.CONSUMABLE) && inventory.Exists(x => x.Game_item_name.Equals(gi.Game_item_name))){
            ((Consumable)inventory[inventory.FindIndex(x => x.Game_item_name.Equals(gi.Game_item_name))]).Quantity++;
        }
        else
        {
            inventory.Add(gi);
        }
    }

    public void RemoveItem(GameItem gi)
    {
        if(gi.Game_Item_Type.Equals(GameItem.GAME_ITEM_TYPE.CONSUMABLE) && inventory.Exists(x => x.Game_item_name.Equals(gi.Game_item_name)))
        {
            ((Consumable)inventory[inventory.FindIndex(x => x.Game_item_name.Equals(gi.Game_item_name))]).Quantity--;
            if (((Consumable)inventory[inventory.FindIndex(x => x.Game_item_name.Equals(gi.Game_item_name))]).Quantity == 0)
                inventory.Remove(gi);
        }
        else
        {
            inventory.Remove(gi);
        }
    }
}