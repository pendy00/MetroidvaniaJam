using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : InputDevice
{
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

        if (Input.GetKey(KeyCode.LeftShift))
            player_input.Jump = true;

        if (Input.GetKey(KeyCode.Space))
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