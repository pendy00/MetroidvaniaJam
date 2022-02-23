using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// load and init all the player's required script to work properly
public class PlayerScriptsLoader : MonoBehaviour
{
    private PlayerInput player_input;
    private InputDevice input_device;

    private PlayerMovements player_movements;
    private PlayerAnimations player_animations;
    private PlayerFX player_fx;

    private PlayerInputController player_input_controller;
    private PlayerMovementsController player_movements_controller;
    private PlayerFXController player_fx_controller;
    private PlayerAnimationsController player_animations_controller;

    public PlayerMovementsController Player_movements_controller { get => player_movements_controller; set => player_movements_controller = value; }
    public PlayerFXController Player_fx_controller { get => player_fx_controller; set => player_fx_controller = value; }
    public PlayerAnimationsController Player_animations_controller { get => player_animations_controller; set => player_animations_controller = value; }

    // find and load scripts
    public void LoadPlayer()
    {
        player_input = new PlayerInput();
        input_device = ScriptsLoader.LoadScript<InputDevice>();

        player_movements = ScriptsLoader.LoadScript<PlayerMovements>();
        player_animations = ScriptsLoader.LoadScript<PlayerAnimations>();
        player_fx = ScriptsLoader.LoadScript<PlayerFX>();

        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();

        player_movements_controller = ScriptsLoader.LoadScript<PlayerMovementsController>();
        player_fx_controller = ScriptsLoader.LoadScript<PlayerFXController>();
        player_animations_controller = ScriptsLoader.LoadScript<PlayerAnimationsController>();

        InitPlayer();
    }

    // initialize and connect scripts
    public void InitPlayer()
    {
        player_input_controller.Init(player_input, input_device);
        player_animations_controller.Init(player_animations);
        player_fx_controller.Init(player_fx);
        player_movements_controller.Init(player_movements, player_animations_controller, player_fx_controller, player_input_controller);
    }
}