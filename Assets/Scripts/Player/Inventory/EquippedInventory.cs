using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventory : MonoBehaviour
{
    private List<GameItem> inventory;
    private int selected_item;

    public List<GameItem> Inventory_Items { get => inventory; set => inventory = value; }
    public int Selected_Item { get => selected_item; set => selected_item = value; }

    //creare parametri per ogni elemento che compone l'equipaggiamento
    public Equipable EquipItem(Equipable gi)
    {
        Equipable temp = null;
        switch (gi.Game_Item_Type)
        {
            //inserire caso per ogni elemento che compone l'equipaggiamento
            default:
                break;
        }
        return temp;
    }

    public Equipable UnequipItem(Equipable gi)
    {
        switch (gi.Game_Item_Type)
        {
            default:
                break;
        }

        return gi;
    }

    public void SelectNextItem()
    {
        if (selected_item <= inventory.Count)
            selected_item++;
    }

    public void SelectPreviousItem()
    {
        if (selected_item > 0)
            selected_item--;
    }
}