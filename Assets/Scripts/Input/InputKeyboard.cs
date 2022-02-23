using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// get input from keyboard
public class InputKeyboard : InputDevice
{
    // update player input status from pressed keys
    public override void UpdateInput(PlayerInput player_input)
    {
        if (Input.GetKey(KeyCode.RightArrow))
            player_input.Right = true;

        if (Input.GetKey(KeyCode.LeftArrow))
            player_input.Left = true;

        if (Input.GetKey(KeyCode.UpArrow))
            player_input.Up = true;

        if (Input.GetKey(KeyCode.DownArrow))
            player_input.Down = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            player_input.Right_single_press = true;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            player_input.Left_single_press = true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            player_input.Up_single_press = true;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            player_input.Down_single_press = true;

        if (Input.GetKey(KeyCode.LeftShift))
            player_input.Jump = true;

        if (Input.GetKeyDown(KeyCode.Space))
            player_input.Action = true;

        if (Input.GetKey(KeyCode.LeftControl))
            player_input.Attack = true;

        if (Input.GetKeyDown(KeyCode.C))
            player_input.Menu = true;

        if (Input.GetKeyDown(KeyCode.X))
            player_input.Cancel = true;

        if (Input.GetKeyDown(KeyCode.S))
            player_input.Run = !player_input.Run;
    }
}