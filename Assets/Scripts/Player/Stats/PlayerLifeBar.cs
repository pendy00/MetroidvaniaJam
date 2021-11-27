using UnityEngine;

public class PlayerLifeBar : MonoBehaviour
{
    public float energia_base;
    private float energia_attuale;
    private float energia_massima;

    public float Energia_Attuale { get => energia_attuale; set => energia_attuale = value; }
    public float Energia_Massima { get => energia_massima; set => energia_massima = value; }

    private void Awake()
    {
        ResetValues();
    }
    public void ResetValues()
    {
        energia_attuale = energia_massima = energia_base;
    }

    public void UpdateEnergiaAttuale(float value, PlayerLives vite)
    {
        if(energia_attuale <= energia_massima && energia_attuale > 0)
        {
            energia_attuale += value;

            if (energia_attuale <= 0)
                vite.UpdateViteAttuale(-1);
        }
            
    }

    public void UpdateEnergiaMassima(float value)
    {
        energia_massima += value;
    }

    public float EnergiaAttualePercentuale() 
    {
        return (energia_attuale / energia_massima);
    }
}