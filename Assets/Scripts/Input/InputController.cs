using UnityEngine;

// classe che fa da tramite tra l'interazione del giocatore e gli elementi di scena
public class InputController : MonoBehaviour
{
    // movimenti personaggio
    private bool up;
    private bool down;
    private bool right;
    private bool left;

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