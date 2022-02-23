using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<GameItem> items;

    public List<GameItem> Items { get => items; set => items = value; }
    public int Item_count { get => items.Count; }

    private void Awake()
    {
        items = new List<GameItem>();
    }

    public void AddItem(GameItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(GameItem item)
    {
        items.Remove(item);
    }

    public GameItem FindItem(GameItem item)
    {
        return items.Find(x => x.Item_name.Equals(item.Item_name));
    }
}