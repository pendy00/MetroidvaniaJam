using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<Image> items;

    private int selected;

    public int Selected { get => selected; set => selected = value; }

    private void Awake()
    {
        items = new List<Image>();
        selected = 0;
    }

    public void ShowInventory(List<GameItem> hold_items)
    {
        foreach(GameItem gi in hold_items)
        {
            Image temp = null;
            switch (gi.Game_Item_Type)
            {
                //
                default:
                    break;
            }

            items.Add(temp);
        }
    }
}