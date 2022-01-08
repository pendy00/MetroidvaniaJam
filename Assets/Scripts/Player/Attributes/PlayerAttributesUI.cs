using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributesUI : MonoBehaviour
{
    public Image player_attributes_card;
    public Image player_portrait;
    public GameObject attribute_ui;

    private GridLayoutGroup grid;

    private void Awake()
    {
        grid = GetComponentInChildren<GridLayoutGroup>();
    }

    public void UpdateUI(params Attribute[] attributes)
    {
        RemoveAllAttributes();

        foreach(Attribute a in attributes)
        {
            GameObject temp = Instantiate(attribute_ui);
            temp.GetComponent<Text>().text = a.Attribute_name + " : " + a.Current_value.ToString();
            temp.transform.SetParent(grid.transform);
        }
    }

    public void RemoveAllAttributes()
    {
        foreach (Transform t in grid.transform)
            Destroy(t.gameObject);
    }

    //show stats in the menu tab
    public void ShowUIStats(bool value, params Attribute[] attributes)
    {
        if (value)
            UpdateUI(attributes);

        player_attributes_card.color = value ? Color.white : Color.clear;
        player_portrait.color = value ? Color.white : Color.clear;
        grid.gameObject.SetActive(value);
    }
}