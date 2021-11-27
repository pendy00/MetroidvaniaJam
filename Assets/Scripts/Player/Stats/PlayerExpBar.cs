using UnityEngine;

public class PlayerExpBar : MonoBehaviour
{
    public float esperienza_base;
    private float esperienza_attuale;
    private float esperienza_massima;

    public float Esperienza_Attuale { get => esperienza_attuale; set => esperienza_attuale = value; }
    public float Esperienza_Massima { get => esperienza_massima; set => esperienza_massima = value; }

    private void Awake()
    {
        ResetValues();
    }

    public void ResetValues()
    {
        esperienza_attuale = 0;
        esperienza_massima = esperienza_base;
    }

    public void UpdateEsperienzaAttuale(float value, PlayerLevel player_level)
    {
        esperienza_attuale += value;

        if (esperienza_attuale < 0)
            esperienza_attuale = 0;
        if(esperienza_attuale == esperienza_massima)
        {
            esperienza_attuale = 0;
            player_level.UpdateLivelloAttuale(+1);
        }

        if(esperienza_attuale > esperienza_massima)
        {
            esperienza_attuale -= esperienza_massima;
            player_level.UpdateLivelloAttuale(+1);
        }
    }

    public void UpdateEsperienzaMassima(float value)
    {
        esperienza_massima += value;
    }

    public float EsperienzaAttualePercentuale()
    {
        return ((esperienza_attuale / esperienza_massima));
    }
}