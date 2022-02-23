using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentUI : MonoBehaviour
{
    private Image background;
    private GridLayoutGroup grid;

    private void Awake()
    {
        background = GetComponentInChildren<Image>();
        grid = GetComponentInChildren<GridLayoutGroup>();
    }

    public void ShowInventoryUI(bool value)
    {
        background.color = value ? Color.white : Color.clear;
        grid.gameObject.SetActive(value);
    }
}
