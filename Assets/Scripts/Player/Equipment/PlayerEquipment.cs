using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private Equipable weapon_slot;
    [SerializeField]
    private Equipable armor_slot;
    [SerializeField]
    private Equipable accessory_slot_1;
    [SerializeField]
    private Equipable accessory_slot_2;

    private void Awake()
    {
        weapon_slot = null;
        armor_slot = null;
        accessory_slot_1 = null;
        accessory_slot_2 = null;
    }

    public Equipable Equip(Equipable e)
    {
        Equipable temp = null;
        switch (e.Equipable_type)
        {
            case EquipableTypes.EQUIPABLE_TYPES.WEAPON:
                temp = weapon_slot;
                weapon_slot = e;
                return temp;
            case EquipableTypes.EQUIPABLE_TYPES.ARMOR:
                temp = armor_slot;
                armor_slot = e;
                return temp;
            case EquipableTypes.EQUIPABLE_TYPES.ACCESSORY:
                if(accessory_slot_1 != null && accessory_slot_2 != null)
                { temp = accessory_slot_1; accessory_slot_1 = e; return temp; }    
                else if(accessory_slot_1 != null)
                { accessory_slot_2 = e; return null; }
                else
                { accessory_slot_1 = e; return null; }
            default:
                return null;
        }
    }

    public Equipable Unequip(Equipable e)
    {
        Equipable temp = null;
        switch (e.Equipable_type)
        {
            case EquipableTypes.EQUIPABLE_TYPES.WEAPON:
                temp = weapon_slot;
                weapon_slot = null;
                return temp;
            case EquipableTypes.EQUIPABLE_TYPES.ARMOR:
                temp = armor_slot;
                armor_slot = null;
                return temp;
            case EquipableTypes.EQUIPABLE_TYPES.ACCESSORY:
                if (e.Item_name.Equals(accessory_slot_1.Item_name))
                {
                    temp = accessory_slot_1;
                    accessory_slot_1 = null;
                }else if (e.Item_name.Equals(accessory_slot_2.Item_name))
                {
                    temp = accessory_slot_2;
                    accessory_slot_2 = null;
                }
                return temp;
            default:
                return null;
        }
    }
}