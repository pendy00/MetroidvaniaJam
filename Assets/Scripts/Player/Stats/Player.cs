using UnityEngine;

//contiene tutte le statistiche del giocatore
public class Player : MonoBehaviour
{
    private int energia_attuale;
    private int energia_massima;

    //le statistiche vengono impostate da valori base che vengono aumentati tramite calcoli derivati da livello ed equipaggiamento
    private int forza_base;
    private int costituzione_base;
    private int intelligenza_base;
    private int fortuna_base;

    //statistiche per gestire il livello del giocatore
    private int livello_attuale;
    private int esperienza_attuale;
    private int esperienza_livello_successivo;

    // numero di vite del giocatore
    private int vite;

    public int Energia_attuale { get => energia_attuale; set => energia_attuale = value; }
    public int Energia_massima { get => energia_massima; set => energia_massima = value; }
    public int Forza { get => forza_base; set => forza_base = value; }
    public int Livello { get => livello_attuale; set => livello_attuale = value; }
    public int Esperienza_attuale { get => esperienza_attuale; set => esperienza_attuale = value; }
    public int Esperienza_livello_successivo { get => esperienza_livello_successivo; set => esperienza_livello_successivo = value; }
    public int Vite { get => vite; set => vite = value; }
    public int Costituzione { get => costituzione_base; set => costituzione_base = value; }
    public int Intelligenza { get => intelligenza_base; set => intelligenza_base = value; }
    public int Fortuna { get => fortuna_base; set => fortuna_base = value; }
}