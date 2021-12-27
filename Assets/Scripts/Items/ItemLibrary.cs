using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour
{
    public const string bandage = "bandage";
    public GameObject bandage_prefab;
    private Sprite bandage_ui;
    public int bandage_healing_power;

    public const string medicine = "medicine";
    public GameObject medicine_prefab;
    private Sprite medicine_ui;
    public int medicine_healing_power;

    public string Bandage { get => bandage; }
    public int Bandage_healing_power { get => bandage_healing_power; set => bandage_healing_power = value; }

    public string Medicine { get => medicine; }
    public int Medicine_healing_power { get => medicine_healing_power; set => medicine_healing_power = value; }

    private void Awake()
    {
        bandage_ui = bandage_prefab.GetComponent<SpriteRenderer>().sprite;
        medicine_ui = medicine_prefab.GetComponent<SpriteRenderer>().sprite;
    }

    public Sprite GetItemUI(string item_name)
    {
        switch(item_name)
        {
            case bandage:
                return bandage_ui;
            case medicine:
                return medicine_ui;
            default:
                return null;
        }
    }
}