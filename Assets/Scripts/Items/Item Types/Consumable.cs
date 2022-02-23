using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : GameItem
{
    public Consumable()
    {

    }
    public Consumable(int item_quantity)
    {
        Item_quantity = item_quantity;
    }

    public void UseItem(int value)
    {
        if (Item_quantity + value < 0)
            return;

        Item_quantity += value;
    }
}