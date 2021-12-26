using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private Weapon weapon;
    private Equipable armor;
    private Equipable accessory_1;
    private Equipable accessory_2;

    public Weapon Weapon { get => weapon; set => weapon = value; }
    public Equipable Armor { get => armor; set => armor = value; }
    public Equipable Accessory_1 { get => accessory_1; set => accessory_1 = value; }
    public Equipable Accessory_2 { get => accessory_2; set => accessory_2 = value; }
}