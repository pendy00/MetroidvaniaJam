using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableUI : GameItemUI
{
    public int item_quantity;

    public void Awake()
    {
        Game_item = new Consumable(item_quantity);
    }
}