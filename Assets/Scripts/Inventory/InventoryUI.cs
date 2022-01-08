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
    }

    public void AddItem(Collectable item, Sprite sprite)
    {
        GameObject temp = Instantiate(item_ui);
        InventoryUIItem temp_ui = temp.GetComponent<InventoryUIItem>();
        temp_ui.UpdateItemImage(sprite);
        temp_ui.UpdateItemText(item.item_name, item.item_quantity.ToString());
        temp.transform.SetParent(grid.transform);
        temp.transform.localScale = Vector3.one;
    }

    public void UpdateUI(List<Collectable> items, ItemLibrary item_library)
    {
        RemoveAllItem();

        foreach(Collectable c in items)
            AddItem(c, item_library.GetItemUI(c.Item_name));
    }

    public void RemoveItem(Collectable item)
    {
        foreach(InventoryUIItem i in grid.transform)
        {
            if (i.Item_text.Contains(item.Item_name))
                Destroy(i.gameObject);
        }    
    }

    public void RemoveAllItem()
    {
        foreach (Transform t in grid.transform)
            Destroy(t.gameObject);
    }

    public void ShowInventoryUI(bool value)
    {
        background.color = value ? Color.white : Color.clear;
        grid.gameObject.SetActive(value);
    }
}