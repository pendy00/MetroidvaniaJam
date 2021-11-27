using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventory : MonoBehaviour
{
    //creare parametri per ogni elemento che compone l'equipaggiamento
    public GameItem EquipItem(GameItem gi, Inventory i)
    {
        GameItem temp = null;
        switch (gi.Game_Item_Type)
        {
            //inserire caso per ogni elemento che compone l'equipaggiamento
            default:
                break;
        }
        return temp;
    }

    public GameItem UnequipItem(GameItem gi, Inventory i)
    {
        switch (gi.Game_Item_Type)
        {
            default:
                break;
        }

        return null;
    }
}