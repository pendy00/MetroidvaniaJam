using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//an attribute is a value used to calculate result actions made by in game characters
public class Attribute
{
    private string attribute_name;
    private int base_value;
    private int current_value;
    private int max_value;

    private int delta_value;

    public string Attribute_name { get => attribute_name; set => attribute_name = value; }
    public int Base_value { get => base_value; set => base_value = value; }
    public int Current_value { get => current_value; set => current_value = value; }
    public int Max_value { get => max_value; set => max_value = value; }
    public int Delta_value { get => delta_value; set => delta_value = value; }

    public void ChangeAttributeValue(int value)
    {
        current_value += value;

        if (current_value < 0)
            current_value = 0;

        if (current_value > max_value)
            current_value = max_value;
    }

    public void IncreaseMaxValue(int value)
    {
        max_value += value;
    }
}