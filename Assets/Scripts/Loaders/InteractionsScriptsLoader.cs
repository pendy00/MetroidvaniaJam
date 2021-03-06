using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsScriptsLoader : MonoBehaviour
{
    private PlayerCollectController player_collect_controller;
    private PlayerInteractController player_interact_controller;
    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;

    private bool interaction_loaded;

    public bool Interaction_loaded { get => interaction_loaded; set => interaction_loaded = value; }
    public PlayerCollectController Player_collect_controller { get => player_collect_controller; set => player_collect_controller = value; }
    public PlayerInteractController Player_interact_controller { get => player_interact_controller; set => player_interact_controller = value; }

    public void LoadInteractions()
    {
        player_collect_controller = ScriptsLoader.LoadScript<PlayerCollectController>();
        player_interact_controller = ScriptsLoader.LoadScript<PlayerInteractController>();
        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();
        inventory_controller = ScriptsLoader.LoadScript<InventoryController>();

        InitInteractions();

        interaction_loaded = true;
    }

    public void InitInteractions()
    {
        player_collect_controller.Init(player_input_controller, inventory_controller);
        player_interact_controller.Init(player_input_controller);

        player_collect_controller.Init(player_input_controller, inventory_controller);
        player_interact_controller.Init(player_input_controller);
    }
}