using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableUI : GameItemUI
{
    public EquipableTypes.EQUIPABLE_TYPES equipable_type;
    public int level_equired;
    public int life_points;
    public int strenght;
    public int constitution;
    public int intelligence;
    public int luck;

    private void Awake()
    {
        Game_item = new Equipable(level_equired, life_points, strenght, constitution, intelligence, luck);
        ((Equipable)Game_item).Equipable_type = equipable_type;
    }
}