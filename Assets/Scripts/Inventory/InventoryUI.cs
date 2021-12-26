using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Image background;
    private GridLayoutGroup grid;
    public GameObject item_ui;

    private void Awake()
    {
        background = GetComponent<Image>();
        grid = GetComponentInChildren<GridLayoutGroup>();

        ShowInventory(false);
    }

    public void AddItem(Collectable item)
    {
        GameObject temp = Instantiate(item_ui);
        temp.GetComponentInChildren<Image>().sprite = item.Sprite;
        temp.GetComponentInChildren<Text>().text = item.item_name + " : " + item.item_quantity;
        temp.GetComponent<RectTransform>().localScale = Vector3.one;
        temp.transform.SetParent(grid.transform);
    }

    public void RemoveItem(GameObject item_ui)
    {
        GameObject temp = null;
        foreach(GameObject go in grid.transform)
        {
            if (go.name.Equals(item_ui.name))
                temp = go;
        }

        if (temp != null)
            Destroy(temp);
    }

    public void RemoveAllItem()
    {
        foreach (Transform t in grid.transform)
            Destroy(t.gameObject);
    }

    public void ShowInventory(bool value)
    {
        background.color = value ? Color.white : Color.clear;
        grid.gameObject.SetActive(value);
    }
}