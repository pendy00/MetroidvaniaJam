using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesScriptsLoader : MonoBehaviour
{
    private PlayerLifeBeatUI player_life_beat_ui;
    private PlayerUIExpBar player_exp_ui;
    private PlayerUILevel player_level_ui;
    private PlayerUILives player_lives_ui;

    private PlayerAttributes player_attributes;
    private PlayerAttributesUI player_attributes_ui;
    private PlayerStatsUI player_stats_ui;
    private PlayerAttributesController player_attributes_controller;

    private bool attributes_loaded;

    public bool Attributes_loaded { get => attributes_loaded; set => attributes_loaded = value; }

    public void LoadAttributes()
    {
        player_life_beat_ui = ScriptsLoader.LoadScript<PlayerLifeBeatUI>();
        player_exp_ui = ScriptsLoader.LoadScript<PlayerUIExpBar>();
        player_level_ui = ScriptsLoader.LoadScript<PlayerUILevel>();
        player_lives_ui = ScriptsLoader.LoadScript<PlayerUILives>();

        player_attributes = new PlayerAttributes();
        player_attributes_ui = ScriptsLoader.LoadScript<PlayerAttributesUI>();
        player_stats_ui = ScriptsLoader.LoadScript<PlayerStatsUI>();

        player_attributes_controller = ScriptsLoader.LoadScript<PlayerAttributesController>();

        InitAttributes();

        attributes_loaded = true;
    }

    public void InitAttributes()
    {
        player_attributes.Init();
        player_stats_ui.Init(player_life_beat_ui, player_exp_ui, player_lives_ui, player_level_ui);
        player_attributes_controller.Init(player_attributes, player_attributes_ui, player_stats_ui);
    }
}