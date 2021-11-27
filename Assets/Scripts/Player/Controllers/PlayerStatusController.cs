using UnityEngine;

//utilizzata per aumentare/diminuire ogni statistica del giocatore implementando anche controlli come la morte o il level up
public class PlayerStatusController : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //incremento/decremento statistiche
    public void UpdateEnergia(int value)
    {
        player.Energia_attuale += value;
        if (player.Energia_attuale > player.Energia_massima)
            player.Energia_attuale = player.Energia_massima;

        //se l'energia del giocatore è inferiore o uguale a 0 il giocatore "muore"
        if (player.Energia_attuale <= 0)
            PlayerDeath();
    }

    public void UpdateEnergiaMax(int value)
    {
        player.Energia_massima += value;
    }

    public void UpdateForza(int value)
    {
        player.Forza += value;
    }

    public void UpdateIntelligenza(int value)
    {
        player.Intelligenza += value;
    }

    public void UpdateCostituzione(int value)
    {
        player.Costituzione += value;
    }

    public void UpdateFortuna(int value)
    {
        player.Fortuna += value;
    }

    public void UpdateLivello(int value)
    {
        player.Livello += value;
    }

    public void UpdateEsperienzaAttuale(int value)
    {
        player.Esperienza_attuale += value;

        //se l'esperienza del giocatore raggiunge o supera l'esperienza indicata per il livello successivo, il giocatore sale di livello
        if (player.Esperienza_attuale >= player.Esperienza_livello_successivo)
        {
            LevelUp();

            //se l'esperienza guadagnata per il level up supera l'esperienza massima, l'esperienza restante viene aggiunta come esperienza per il livello successivo altrimenti viene settata a 0
            if (player.Esperienza_attuale > player.Esperienza_livello_successivo)
                player.Esperienza_attuale = player.Esperienza_attuale - player.Esperienza_livello_successivo;
            else
                player.Esperienza_attuale = 0;
        }
    }

    public void UpdateEsperienzaLivelloSuccessivo(int value)
    {
        player.Esperienza_livello_successivo += value;
    }

    public void UpdateVite(int value)
    {
        player.Vite += value;
        //se le vite del giocatore scendono a 0 la partita viene terminata
        if(player.Vite <= 0)
        {
            // game over;
        }
    }

    public void PlayerDeath()
    {
        UpdateVite(-1);
    }

    public void LevelUp()
    {
        UpdateLivello(+1);

        //calcolo delle statistiche del giocatore tramite i valori base ed il livello
        //incremento statistiche ed esperienza livello successivo
        
    }
}