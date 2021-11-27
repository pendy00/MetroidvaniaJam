using UnityEngine;

//gestisce il livello del personaggio
public class PlayerLevel : MonoBehaviour
{
    private PlayerStatsController stats_controller;
    private int livello_base;
    private int livello_attuale;
    public int livello_massimo;

    public int Livello_base { get => livello_base; set => livello_base = value; }
    public int Livello_attuale { get => livello_attuale; set => livello_attuale = value; }
    public int Livello_massimo { get => livello_massimo; set => livello_massimo = value; }

    //eliminare awake e start una volta creato il game manager
    private void Awake()
    {
        ResetLevel();
    }

    private void Start()
    {
        stats_controller = FindObjectOfType<PlayerStatsController>();
    }

    public void ResetLevel()
    {
        livello_attuale = Livello_base;
    }

    public void UpdateLivelloAttuale(int value)
    {
        if(livello_attuale < livello_massimo)
            livello_attuale += value;

        stats_controller.UpdatePlayerStats();
    }
}