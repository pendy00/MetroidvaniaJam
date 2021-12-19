using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // movimenti personaggio
    private bool up;
    private bool down;
    private bool right;
    private bool left;
    private float running; //corsa personaggio

    //azioni personaggio
    private bool jump;
    private bool crouch;
    private bool action;
    private bool attack;

    // opzioni/menu
    private bool menu;
    private bool cancel;

    public bool Up { get => up; set => up = value; }
    public bool Down { get => down; set => down = value; }
    public bool Right { get => right; set => right = value; }
    public bool Left { get => left; set => left = value; }
    public bool Jump { get => jump; set => jump = value; }
    public bool Crouch { get => crouch; set => crouch = value; }
    public bool Action { get => action; set => action = value; }
    public bool Menu { get => menu; set => menu = value; }
    public bool Cancel { get => cancel; set => cancel = value; }
    public bool Attack { get => attack; set => attack = value; }
    public float Running { get => running; set => running = value; }

    // metodi per resettare gli input ricevuti per evitare che alcuni valori restino bloccati
    public void ResetAxis()
    {
        up = down = left = right = false;
    }

    public void ResetActions()
    {
        jump = crouch = action = attack = false;
    }

    public void ResetOptions()
    {
        menu = cancel = false;
    }

    public void ResetAllInputs()
    {
        ResetAxis();
        ResetActions();
        ResetOptions();
    }
}