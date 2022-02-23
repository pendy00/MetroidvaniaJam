using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//an attribute is a value used to calculate result actions and states of in game characters
public class Attribute
{
    private string attribute_name; // name of the attribute
    private int base_value; // base value is used to calculate value upgrades or degrades
    private int current_value; // current value used to calculate the action result
    private int max_value; // cap value of the attribute

    private int delta_value; // used to upgrade or degrade a value in a semi-random way

    public string Attribute_name { get => attribute_name; set => attribute_name = value; }
    public int Base_value { get => base_value; set => base_value = value; }
    public int Current_value { get => current_value; set => current_value = value; }
    public int Max_value { get => max_value; set => max_value = value; }
    public int Delta_value { get => delta_value; set => delta_value = value; }

    // manage value changing considering min and max calue boundaries
    public void ChangeAttributeValue(int value)
    {
        current_value += value;

        if (current_value < 0)
            current_value = 0;

        if (current_value > max_value)
            current_value = max_value;
    }
}