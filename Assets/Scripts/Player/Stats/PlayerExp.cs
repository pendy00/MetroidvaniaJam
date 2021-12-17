using UnityEngine;

// gestisce l'esperienza del personaggio
public class PlayerExp : MonoBehaviour
{
    public int esperienza_base;
    private int esperienza_attuale;
    private int esperienza_livello_successivo;

    public int Esperienza_Base { get => esperienza_base; set => esperienza_base = value; }
    public int Esperienza_Attuale { get => esperienza_attuale; set => esperienza_attuale = value; }
    public int Esperienza_Livello_Successivo { get => esperienza_livello_successivo; set => esperienza_livello_successivo = value; }

    //reimpostazione dei valori a stato di default
    public void ResetValues()
    {
        esperienza_attuale = 0;
        esperienza_livello_successivo = esperienza_base;
    }

    //aggiorna l'esperienza del giocatore ed aumenta di livello se necessario
    public void UpdateEsperienzaAttuale(int value, PlayerStats player_stats)
    {
        esperienza_attuale += value;

        //se l'esperienza del giocatore raggiunge o supera l'esperienza indicata per il livello successivo, il giocatore sale di livello
        if (esperienza_attuale >= esperienza_livello_successivo)
        {
            LevelUp(player_stats);

            //se l'esperienza guadagnata per il level up supera l'esperienza massima, l'esperienza restante viene aggiunta come esperienza per il livello successivo altrimenti viene settata a 0
            if (esperienza_attuale > esperienza_livello_successivo)
                esperienza_attuale = esperienza_attuale - esperienza_livello_successivo;
            else
                esperienza_attuale = 0;
        }
    }

    public void LevelUp(PlayerStats player_stats)
    {
        player_stats.Player_level.UpdateLivelloAttuale(+1, player_stats);
    }

    //aggiorna l'esperienza massima
    public void UpdateEsperienzaMassima(int value)
    {
        esperienza_livello_successivo += value;
    }

    //restituisce il valore percentuale dell'esperienza attuale
    public float EsperienzaAttualePercentuale()
    {
        return ((esperienza_attuale / esperienza_livello_successivo));
    }
}