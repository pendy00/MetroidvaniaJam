using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameItem
{
    [SerializeField]
    private string item_name;
    [SerializeField]
    private int item_quantity;
    public string Item_name { get => item_name; set => item_name = value; }
    public int Item_quantity { get => item_quantity; set => item_quantity = value; }
    public GameItem() { }
}