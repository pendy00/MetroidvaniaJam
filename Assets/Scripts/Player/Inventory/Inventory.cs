using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /*
    private List<GameItem> inventory;
    private int selected_item = 0;

    public List<GameItem> Inventory_Items { get => inventory; set => inventory = value; }
    public int Selected_Item { get => selected_item; set => selected_item = value; }

    private void Start()
    {
        inventory = new List<GameItem>();
    }

    public void AddItem(GameItem gi)
    {
        if(gi.Game_Item_Type.Equals(GameItem.GAME_ITEM_TYPE.CONSUMABLE) && inventory.Exists(x => x.Game_item_name.Equals(gi.Game_item_name)))
            ((Consumable)inventory[inventory.FindIndex(x => x.Game_item_name.Equals(gi.Game_item_name))]).Quantity++;
        else
            inventory.Add(gi);
    }

    public void RemoveItem(GameItem gi)
    {
        if(gi.Game_Item_Type.Equals(GameItem.GAME_ITEM_TYPE.CONSUMABLE) && inventory.Exists(x => x.Game_item_name.Equals(gi.Game_item_name)))
        {
            Consumable temp = (Consumable)inventory[inventory.FindIndex(x => x.Game_item_name.Equals(gi.Game_item_name))];

            temp.UseItemSingle();

            if (temp.Quantity == 0)
                inventory.Remove(gi);
        }
        else
            inventory.Remove(gi);
    }

    public void SelectNextItem()
    {
        if (selected_item < inventory.Count - 1)
            selected_item++;
    }

    public void SelectPreviousItem()
    {
        if (selected_item > 0)
            selected_item--;
    }
    */
}