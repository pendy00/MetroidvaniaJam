using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUIItem : MonoBehaviour
{
    private Image item_image;
    private Text item_text;

    public string Item_text { get => item_text.text; set => item_text.text = value; }

    public void Awake()
    {
        item_image = GetComponentInChildren<Image>();
        item_text = GetComponentInChildren<Text>();
    }

    public void UpdateItemImage(Image image)
    {
        item_image.sprite = image.sprite;
    }

    public void UpdateItemImage(Sprite sprite)
    {
        item_image.sprite = sprite;
    }

    public void UpdateItemText(string name, string quantity)
    {
        item_text.text = name + ": " + quantity;
    }
}