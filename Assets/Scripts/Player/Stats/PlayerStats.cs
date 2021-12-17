using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerLifePoints player_life_points;
    private PlayerExp player_exp;
    private PlayerLevel player_level;
    private PlayerLives player_lives;

    public int punti_ferita_base;
    public int esperienza_livello_successivo_base;
    public int vite;

    //le statistiche vengono impostate da valori base che vengono aumentati tramite calcoli derivati da livello ed equipaggiamento
    public int forza_base;
    private int forza_base_delta;
    private int forza_attuale;
    public int forza_massima;
    public int costituzione_base;
    private int costituzione_base_delta;
    private int costituzione_attuale;
    public int costituzione_massima;
    public int intelligenza_base;
    private int intelligenza_base_delta;
    private int intelligenza_attuale;
    public int intelligenza_massima;
    public int fortuna_base;
    private int fortuna_base_delta;
    private int fortuna_attuale;
    public int fortuna_massima;

    public int Forza_base { get => forza_base; set => forza_base = value; }
    public int Forza_attuale { get => forza_attuale; set => forza_attuale = value; }
    public int Forza_base_delta { get => forza_base_delta; set => forza_base_delta = value; }
    public int Costituzione_base { get => costituzione_base; set => costituzione_base = value; }
    public int Costituzione_attuale { get => costituzione_attuale; set => costituzione_attuale = value; }
    public int Costituzione_base_delta { get => costituzione_base_delta; set => costituzione_base_delta = value; }
    public int Intelligenza_base { get => intelligenza_base; set => intelligenza_base = value; }
    public int Intelligenza_attuale { get => intelligenza_attuale; set => intelligenza_attuale = value; }
    public int Intelligenza_base_delta { get => intelligenza_base_delta; set => intelligenza_base_delta = value; }
    public int Fortuna_base { get => fortuna_base; set => fortuna_base = value; }
    public int Fortuna_attuale { get => fortuna_attuale; set => fortuna_attuale = value; }
    public int Fortuna_base_delta { get => fortuna_base_delta; set => fortuna_base_delta = value; }

    public PlayerLifePoints Player_life_points { get => player_life_points; set => player_life_points = value; }
    public PlayerExp Player_exp { get => player_exp; set => player_exp = value; }
    public PlayerLevel Player_level { get => player_level; set => player_level = value; }
    public PlayerLives Player_lives { get => player_lives; set => player_lives = value; }

    public void InitializeValues()
    {
        Player_life_points.Punti_ferita_massimi = Player_life_points.Punti_ferita_attuali = punti_ferita_base;
        Player_exp.Esperienza_Livello_Successivo = esperienza_livello_successivo_base;
        player_exp.Esperienza_Attuale = 0;
        player_level.Livello_attuale = 0;
        player_lives.Vite_attuale = vite;

        forza_attuale = forza_base;
        costituzione_attuale = costituzione_base;
        intelligenza_attuale = intelligenza_base;
        fortuna_attuale = fortuna_base;
    }
    public void UpdateForza(int value)
    {
        forza_attuale += value;

        forza_attuale = CheckCapValues(forza_attuale, forza_massima);
    }

    public void UpdateIntelligenza(int value)
    {
        intelligenza_attuale += value;

        intelligenza_attuale = CheckCapValues(intelligenza_attuale, intelligenza_massima);
    }

    public void UpdateCostituzione(int value)
    {
        costituzione_attuale += value;

        costituzione_attuale = CheckCapValues(costituzione_attuale, costituzione_massima);
    }

    public void UpdateFortuna(int value)
    {
        fortuna_attuale += value;

        fortuna_attuale = CheckCapValues(fortuna_attuale, fortuna_massima);
    }

    private int CheckCapValues(int valore_attuale, int valore_massimo)
    {
        if (valore_attuale > valore_massimo)
            valore_attuale = valore_massimo;

        if (valore_attuale < 0)
            valore_attuale = 0;

        return valore_attuale;
    }

    public void LevelUpStats()
    {
        forza_attuale += CalculateLevelUpStat(forza_base, forza_base_delta);
        costituzione_attuale += CalculateLevelUpStat(costituzione_base, costituzione_base_delta);
        intelligenza_attuale += CalculateLevelUpStat(intelligenza_base, intelligenza_base_delta);
        fortuna_attuale += CalculateLevelUpStat(fortuna_base, fortuna_base_delta);
    }

    private int CalculateLevelUpStat(int valore_base, int valore_delta)
    {
        return valore_base + Random.Range(-valore_delta, valore_delta) + player_level.Livello_attuale;
    }
}