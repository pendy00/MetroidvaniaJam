using UnityEngine;

//gestisce il livello del personaggio
public class PlayerLevel : MonoBehaviour
{
    private int livello_attuale;
    public int livello_massimo;

    public int Livello_attuale { get => livello_attuale; set => livello_attuale = value; }
    public int Livello_massimo { get => livello_massimo; set => livello_massimo = value; }

    public void ResetLevel()
    {
        livello_attuale = 0;
    }

    public void UpdateLivelloAttuale(int value, PlayerStats player_stats)
    {
        if(livello_attuale < livello_massimo)
        {
            livello_attuale += value;
            player_stats.LevelUpStats();
        }
    }
}