using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesController : MonoBehaviour
{
    //private string life_points = "life points";
    public int starting_life_points;
    public int max_life_point;
    //private string exp_points = "experience points";
    public int starting_exp_point;
    public int max_exp_point;
    //private string level = "level";
    public int starting_level;
    public int max_level;
    //private string lives = "lives";
    public int starting_lives;
    public int max_lives;
    private string strenght = "strenght";
    public int strating_strenght;
    public int max_strenght;
    private string constitution = "constitution";
    public int starting_constitution;
    public int max_constitution;
    private string intelligence = "intelligence";
    public int starting_intelligence;
    public int max_intelligence;
    private string luck = "luck";
    public int starting_luck;
    public int max_luck;

    private PlayerAttributes player_attributes;
    private PlayerAttributesUI player_attributes_ui;
    private PlayerStatsUI player_stats_ui;

    public PlayerAttributes Player_attributes { get => player_attributes; set => player_attributes = value; }
    public PlayerAttributesUI Player_attributes_ui { get => player_attributes_ui; set => player_attributes_ui = value; }

    public void Init(PlayerAttributes player_attributes, PlayerAttributesUI player_attributes_ui, PlayerStatsUI player_stats_ui)
    {
        this.player_attributes = player_attributes;

        player_attributes.Life_point.Max_value = starting_life_points; // set max life points in order to be able to update them
        this.player_attributes.UpdateAllMaxValues(max_life_point, max_exp_point, max_level, max_lives, max_strenght, max_constitution, max_intelligence, max_luck);
        this.player_attributes.UpdateAllValues(starting_life_points, 0, starting_level, starting_lives, strating_strenght, starting_constitution, starting_intelligence, starting_luck);
        this.player_attributes.Strenght.Attribute_name = strenght;
        this.player_attributes.Constitution.Attribute_name = constitution;
        this.player_attributes.Intelligence.Attribute_name = intelligence;
        this.player_attributes.Luck.Attribute_name = luck;

        this.player_attributes_ui = player_attributes_ui;
        this.player_stats_ui = player_stats_ui;

        player_stats_ui.UpdateAllUI(player_attributes.Life_point.Current_value, player_attributes.Exp_point.Current_value, player_attributes.Level.Current_value, player_attributes.Lives.Current_value);
    }

    public void UpdateLifePoint(int value)
    {
        player_attributes.Life_point.ChangeAttributeValue(value);
        player_stats_ui.UpdateLifeBeatUI(player_attributes.Life_point.Current_value);
        if(player_attributes.Life_point.Current_value <= 0)
        {
            UpdateLives(-1);
        }
    }

    public void UpdateLives(int value)
    {
        player_attributes.Lives.ChangeAttributeValue(value);
        player_stats_ui.Lives_ui.UpdateVite(player_attributes.Lives.Current_value);
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

        player_stats_ui.Exp_bar_ui.UpdateExpBar(player_attributes.Exp_point.Current_value);
    }

    public void LevelUp()
    {
        player_attributes.Level.ChangeAttributeValue(+1);

        int current_level = player_attributes.Level.Current_value;

        player_attributes.Life_point.Max_value = LevelUpAttribute(player_attributes.Life_point) + current_level;
        player_attributes.Life_point.ChangeAttributeValue(player_attributes.Intelligence.Max_value);

        player_attributes.Exp_point.Max_value = LevelUpAttribute(player_attributes.Exp_point) + current_level;
        player_attributes.Exp_point.Current_value = 0;

        player_attributes.Strenght.Current_value = LevelUpAttribute(player_attributes.Strenght) + current_level;
        player_attributes.Constitution.Current_value = LevelUpAttribute(player_attributes.Constitution) + current_level;
        player_attributes.Intelligence.Current_value = LevelUpAttribute(player_attributes.Intelligence) + current_level;
        player_attributes.Luck.Current_value = LevelUpAttribute(player_attributes.Luck) + current_level;

        player_stats_ui.UpdateAllUI(player_attributes.Life_point.Current_value, player_attributes.Exp_point.Current_value,
                                    player_attributes.Level.Current_value, player_attributes.Lives.Current_value);
    }

    private int LevelUpAttribute(Attribute attribute)
    {
        return attribute.Base_value + Random.Range(-attribute.Delta_value, attribute.Delta_value + 1);
    }

    public void ShowAttributesUI(bool value)
    {
        player_attributes_ui.ShowUIStats(value, player_attributes.Strenght, player_attributes.Constitution, player_attributes.Intelligence, player_attributes.Luck);
    }
}