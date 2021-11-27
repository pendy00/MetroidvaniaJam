using UnityEngine;

// gestisce l'esperienza del personaggio
public class PlayerExp : MonoBehaviour
{
    public float esperienza_base;
    private float esperienza_attuale;
    private float esperienza_massima;

    public float Esperienza_Attuale { get => esperienza_attuale; set => esperienza_attuale = value; }
    public float Esperienza_Massima { get => esperienza_massima; set => esperienza_massima = value; }

    //eliminare dopo l'implementazione di un game manager
    private void Awake()
    {
        ResetValues();
    }

    //reimpostazione dei valori a stato di default
    public void ResetValues()
    {
        esperienza_attuale = 0;
        esperienza_massima = esperienza_base;
    }

    //aggiorna l'esperienza del giocatore ed aumenta di livello se necessario
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

    //aggiorna l'esperienza massima
    public void UpdateEsperienzaMassima(float value)
    {
        esperienza_massima += value;
    }

    //restituisce il valore percentuale dell'esperienza attuale
    public float EsperienzaAttualePercentuale()
    {
        return ((esperienza_attuale / esperienza_massima));
    }
}