using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Equipable : GameItem
{
    [SerializeField]
    private EquipableTypes.EQUIPABLE_TYPES equipable_type;

    [SerializeField]
    private int level_required;
    [SerializeField]
    private int life_points;
    [SerializeField]
    private int strenght;
    [SerializeField]
    private int constitution;
    [SerializeField]
    private int intelligence;
    [SerializeField]
    private int luck;

    public int Level_required { get => level_required; set => level_required = value; }
    public int Life_points { get => life_points; set => life_points = value; }
    public int Strenght { get => strenght; set => strenght = value; }
    public int Constitution { get => constitution; set => constitution = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Luck { get => luck; set => luck = value; }
    public EquipableTypes.EQUIPABLE_TYPES Equipable_type { get => equipable_type; set => equipable_type = value; }

    public Equipable()
    {

    }
    public Equipable(int level_required, int life_point, int strenght, int constitution, int intelligence, int luck)
    {
        Item_quantity = 1;
        this.level_required = level_required;
        this.life_points = life_point;
        this.strenght = strenght;
        this.constitution = constitution;
        this.intelligence = intelligence;
        this.luck = luck;
    }
}