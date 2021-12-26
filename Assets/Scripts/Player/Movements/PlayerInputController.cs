using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput player_input;
    private InputDevice input_device;

    public PlayerInput Player_input { get => player_input; set => player_input = value; }
    public InputDevice Input_device { get => input_device; set => input_device = value; }

    public void Init(PlayerInput player_input, InputDevice input_device)
    {
        this.player_input = player_input;
        this.input_device = input_device;
    }

    private void Update()
    {
        player_input.ResetAxis();
        player_input.ResetButtons();
        player_input.ResetOptions();
        
        input_device.UpdateInput(player_input);
    }
}