using UnityEngine;

// classe che fa da tramite tra l'interazione del giocatore e gli elementi di scena
public class InputController : MonoBehaviour
{
    PlayerInput player_input; //classe che gestisce lo stato del giocatore in base agli input dell'utente
    InputDevice input_device; //classe che identifica il dispositivo di input attivo

    public PlayerInput Player_input { get => player_input; set => player_input = value; }
    public InputDevice Input_device { get => input_device; set => input_device = value; }

    //inizializzazione classe input controller
    public void Init(PlayerInput pi, InputDevice id)
    {
        player_input = pi;
        input_device = id;
    }

    //prende input da dispositivio attivo ed aggiorna stato giocatore
    public void Update()
    {
        input_device.GetUserInput(player_input);
    }

    //cambia dispositivo input attivo
    public void ChangeInputDevice(InputDevice new_input_device)
    {
        input_device = new_input_device;
    }
}