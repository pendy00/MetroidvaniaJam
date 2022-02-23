using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    public Canvas canvas;
    public GridLayoutGroup grid;
    public Image cursor;
    public GameObject item_ui;

    public void AddItem(GameItem item, Sprite sprite)
    {
        GameObject temp = Instantiate(item_ui);
        PlayerInventoryUIItem temp_ui = temp.GetComponent<PlayerInventoryUIItem>();
        temp_ui.UpdateItemImage(sprite);
        temp_ui.UpdateItemText(item.Item_name, item.Item_quantity.ToString());
        temp.transform.SetParent(grid.transform);
        temp.transform.localScale = Vector3.one;
    }

    public void UpdateUI(List<GameItem> items, ItemLibrary item_library)
    {
        RemoveAllItem();

        foreach(GameItem c in items)
            AddItem(c, item_library.GetItemUI(c.Item_name));
    }

    public void RemoveItem(GameItem item)
    {
        foreach(PlayerInventoryUIItem i in grid.transform)
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
        canvas.gameObject.SetActive(value);
    }

    public void UpdateCursorPosition(int index)
    {
        cursor.rectTransform.position = grid.transform.GetChild(index).GetComponent<RectTransform>().position;
    }
}