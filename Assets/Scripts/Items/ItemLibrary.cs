using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// stores necessary scene items informations
public class ItemLibrary : MonoBehaviour
{
    // bandage
    public const string bandage = "bandage";
    public GameObject bandage_prefab;
    private Sprite bandage_ui;
    public int bandage_healing_power;

    // medicine
    public const string medicine = "medicine";
    public GameObject medicine_prefab;
    private Sprite medicine_ui;
    public int medicine_healing_power;

    // whip
    public const string whip = "whip";
    public GameObject whip_prefab;
    private Sprite whip_ui;
    
    public int Bandage_healing_power { get => bandage_healing_power; set => bandage_healing_power = value; }
    public int Medicine_healing_power { get => medicine_healing_power; set => medicine_healing_power = value; }

    private void Awake()
    {
        bandage_ui = bandage_prefab.GetComponent<SpriteRenderer>().sprite;
        medicine_ui = medicine_prefab.GetComponent<SpriteRenderer>().sprite;
        whip_ui = whip_prefab.GetComponent<SpriteRenderer>().sprite;
    }

    // get item sprite to show on the screen
    public Sprite GetItemUI(string item_name)
    {
        switch(item_name)
        {
            case bandage:
                return bandage_ui;
            case medicine:
                return medicine_ui;
            case whip:
                return whip_ui;
            default:
                return null;
        }
    }

    // destroy item in the scene for non-monobheavior references
    public void DestroyItem(string item_name)
    {
        switch (item_name)
        {
            case whip:
                GameObject w = FindObjectOfType<Whip>().gameObject;
                Destroy(w);
                break;
            default:
                break;
        }
    }

    // get item prefab to be instantiated for non-monobheaviour references
    public GameObject GetItemPrefab(string item_name)
    {
        switch (item_name)
        {
            case whip:
                return whip_prefab;
            default:
                return null;
        }
    }
}