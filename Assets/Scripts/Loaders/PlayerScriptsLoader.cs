using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptsLoader : MonoBehaviour
{
    private PlayerInput player_input;
    private InputDevice input_device;

    private PlayerAttributes player_attributes;

    private PlayerMovements player_movements;
    private PlayerAnimations player_animations;
    private PlayerFX player_fx;

    private PlayerInputController player_input_controller;
    private PlayerAttributesController player_attributes_controller;
    private PlayerMovementsController player_movements_controller;
    private PlayerFXController player_fx_controller;
    private PlayerAnimationsController player_animations_controller;

    private bool player_loaded;

    public bool Player_loaded { get => player_loaded; set => player_loaded = value; }
    public PlayerInputController Player_input_controller { get => player_input_controller; set => player_input_controller = value; }
    public PlayerAttributesController Player_attributes_controller { get => player_attributes_controller; set => player_attributes_controller = value; }
    public PlayerMovementsController Player_movements_controller { get => player_movements_controller; set => player_movements_controller = value; }
    public PlayerFXController Player_fx_controller { get => player_fx_controller; set => player_fx_controller = value; }
    public PlayerAnimationsController Player_animations_controller { get => player_animations_controller; set => player_animations_controller = value; }

    public void LoadPlayer()
    {
        player_input = new PlayerInput();
        input_device = ScriptsLoader.LoadScript<InputDevice>();

        player_attributes = new PlayerAttributes();

        player_movements = ScriptsLoader.LoadScript<PlayerMovements>();
        player_animations = ScriptsLoader.LoadScript<PlayerAnimations>();
        player_fx = ScriptsLoader.LoadScript<PlayerFX>();

        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();

        player_attributes_controller = ScriptsLoader.LoadScript<PlayerAttributesController>();
        player_movements_controller = ScriptsLoader.LoadScript<PlayerMovementsController>();
        player_fx_controller = ScriptsLoader.LoadScript<PlayerFXController>();
        player_animations_controller = ScriptsLoader.LoadScript<PlayerAnimationsController>();

        InitPlayer();
    }

    public void InitPlayer()
    {
        player_input_controller.Init(player_input, input_device);
        player_attributes_controller.Init(player_attributes);
        player_animations_controller.Init(player_animations);
        player_fx_controller.Init(player_fx);
        player_movements_controller.Init(player_movements, player_animations_controller, player_fx_controller, player_input_controller);

        player_loaded = true;
    }
}