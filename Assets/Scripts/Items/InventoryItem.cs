using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : Collectable
{
    private Image item_image;

    public Image Item_image { get => item_image; set => item_image = value; }
}