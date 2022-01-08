using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medics : CollectableObject
{
    private const string item_name = "medicine";
    public int item_quantity;

    private void Awake()
    {
        Collectable_values = new Collectable(item_name, item_quantity);
    }
}