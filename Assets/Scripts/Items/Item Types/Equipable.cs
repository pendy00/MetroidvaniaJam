using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : Collectable
{
    public EquipableTypes.EQUIPABLE_TYPE equipable_type;
    public int life_points;
    public int required_level;
    public int strenght;
    public int require_strenght;
    public int constitution;
    public int require_constitution;
    public int intelligence;
    public int required_intelligence;
    public int luck;
    public int required_luck;
}