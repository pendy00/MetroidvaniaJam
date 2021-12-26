using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesController : MonoBehaviour
{
    public int starting_life_points;
    public int starting_exp_point;
    public int starting_level;
    public int starting_lives;
    public int strating_strenght;
    public int starting_constitution;
    public int starting_intelligence;
    public int starting_luck;

    private PlayerAttributes player_attributes;
    //add ui

    public PlayerAttributes Player_attributes { get => player_attributes; set => player_attributes = value; }

    public void Init(PlayerAttributes player_attributes)
    {
        this.player_attributes = player_attributes;

        this.player_attributes.Init();

        player_attributes.Life_point.Current_value = player_attributes.Life_point.Max_value = starting_life_points;
        player_attributes.Exp_point.Current_value = 0;
        player_attributes.Exp_point.Max_value = starting_exp_point;
        player_attributes.Level.Current_value = starting_level;
        player_attributes.Lives.Current_value = starting_lives;
        player_attributes.Strenght.Current_value = strating_strenght;
        player_attributes.Constitution.Current_value = starting_constitution;
        player_attributes.Intelligence.Current_value = starting_intelligence;
        player_attributes.Luck.Current_value = starting_luck;

        //update ui
    }

    public void UpdateLifePoint(int value)
    {
        player_attributes.Life_point.ChangeAttributeValue(value);
        //update ui
        if(player_attributes.Life_point.Current_value <= 0)
        {
            UpdateLives(-1);
        }
    }

    public void UpdateLives(int value)
    {
        player_attributes.Lives.ChangeAttributeValue(value);
        //update ui
        if(player_attributes.Lives.Current_value > 0 && value < 0)
        {
            //respawn character
        }

        if(player_attributes.Lives.Current_value <= 0)
        {
            //game over
        }
    }

    public void UpdateExpPoint(int value)
    {
        if(player_attributes.Exp_point.Current_value + value >= player_attributes.Exp_point.Max_value)
        {
            int temp = (player_attributes.Exp_point.Current_value + value) - player_attributes.Exp_point.Max_value;
            LevelUp();
            UpdateExpPoint(temp);
        }
        else
        {
            player_attributes.Exp_point.ChangeAttributeValue(value);
        }

        //update ui
    }

    public void LevelUp()
    {
        player_attributes.Level.ChangeAttributeValue(+1);
        //update ui

        int current_level = player_attributes.Level.Current_value;

        player_attributes.Life_point.Max_value = LevelUpAttribute(player_attributes.Life_point) + current_level;
        player_attributes.Life_point.ChangeAttributeValue(player_attributes.Intelligence.Max_value);

        player_attributes.Exp_point.Max_value = LevelUpAttribute(player_attributes.Exp_point) + current_level;
        player_attributes.Exp_point.Current_value = 0;

        player_attributes.Strenght.Current_value = LevelUpAttribute(player_attributes.Strenght) + current_level;
        player_attributes.Constitution.Current_value = LevelUpAttribute(player_attributes.Constitution) + current_level;
        player_attributes.Intelligence.Current_value = LevelUpAttribute(player_attributes.Intelligence) + current_level;
        player_attributes.Luck.Current_value = LevelUpAttribute(player_attributes.Luck) + current_level;
    }

    private int LevelUpAttribute(Attribute attribute)
    {
        return attribute.Base_value + Random.Range(-attribute.Delta_value, attribute.Delta_value + 1);
    }
}