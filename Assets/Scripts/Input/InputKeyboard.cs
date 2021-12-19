using UnityEngine;

// Acquisizione input tramite tastira computer
public class InputKeyboard : InputDevice
{
    public override void GetUserInput(PlayerInput controller)
    {
        controller.ResetAllInputs(); //azzera gli input del frame precedente

        if (Input.GetKeyDown(KeyCode.S)) //abilita/disabilita la corsa
        {
            if (controller.Running == 0.0f)
                controller.Running = 1.0f; //corsa attiva
            else
                controller.Running = 0.0f; //corsa disattiva
        }

        if (Input.GetKey(KeyCode.UpArrow)) //entra in porte ed ascensori
            controller.Up = true;

        if (Input.GetKey(KeyCode.DownArrow)) //accovacciamento in basso
            controller.Crouch = true;

        if (Input.GetKey(KeyCode.RightArrow)) //muove/scorre a destra
            controller.Right = true;

        if (Input.GetKey(KeyCode.LeftArrow)) //muove/scorre a sinistra
            controller.Left = true;

        if (Input.GetKey(KeyCode.Space)) //esegue azione
            controller.Action = true;

        if (Input.GetKey(KeyCode.LeftControl)) //attacco
            controller.Attack = true;

        if (Input.GetKey(KeyCode.LeftShift)) //salto
            controller.Jump = true;

        if (Input.GetKeyDown(KeyCode.C)) //apre menu
            controller.Menu = true;

        if (Input.GetKeyDown(KeyCode.X)) //chiude menu
            controller.Cancel = true;
    }
}