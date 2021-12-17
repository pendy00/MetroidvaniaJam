using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// formatta e deformatta i dati salvati relativi a tutti gli elementi importanti del gioco
public class SavePointDataFormatter
{
    private Player giocatore; //riferimento giocatore per acquisire i dati del giocatore
    private List<GameObject> nemici_placeholder; //riferimento nemici per acquisire i dati di tutti i nemici del livello
    private List<GameObject> livello_placeholder; //riferimento livello per acquisire i dati relativi al livello
    private List<GameObject> inventario_placeholder; //riferimento inventario per acquisire i dati relativi all'inventario

    private const char delimitatore = ','; // utilizzato per dividere ogni singolo componente in fase di salvataggio

    // acquisisce tutti i dati del giocatore e li formatta in una stringa utilizzata per salvare i dati del giocatore
    public string DatiGiocatoreFormat()
    {
        string dati_giocatore = "";
        string posizionex = giocatore.transform.position.x.ToString();
        string posizioney = giocatore.transform.position.y.ToString();
        string posizionez = giocatore.transform.position.z.ToString();
        //string energia_attuale = giocatore.Punti_Ferita_Attuale.ToString();
        //string energ_massima = giocatore.Punti_Ferita_Massimi.ToString();
        //string forza = giocatore.Forza_attuale.ToString();
        //string fortuna = giocatore.Fortuna_attuale.ToString();
        //string livello_attuale = giocatore.Livello_attuale.ToString();
        //string esperienza_attuale = giocatore.Esperienza_attuale.ToString();
        //string esperienza_livello_successivo = giocatore.Esperienza_livello_successivo.ToString();
        //string vite = giocatore.Vite.ToString();

        dati_giocatore += posizionex + delimitatore + posizioney + delimitatore + posizionez + delimitatore;
        //dati_giocatore += energia_attuale + delimitatore + energ_massima + delimitatore + forza + delimitatore + fortuna + delimitatore;
        //dati_giocatore += livello_attuale + delimitatore + esperienza_attuale + delimitatore + esperienza_livello_successivo + delimitatore + vite;

        return dati_giocatore;
    }

    // da una stringa formattata genera un gameobject di tipo giocatore da poter instanziare al caricamento
    public Player DatiGiocatoreDeformat(string dati)
    {
        Player giocatore = new Player();

        string[] reader = dati.Split(delimitatore);

        giocatore.transform.position = new Vector3(float.Parse(reader[0]), float.Parse(reader[1]), float.Parse(reader[2]));
        //giocatore.Punti_Ferita_Attuale = int.Parse(reader[3]);
        //giocatore.Punti_Ferita_Massimi = int.Parse(reader[4]);
        //giocatore.Forza_attuale = int.Parse(reader[5]);
        //giocatore.Fortuna_attuale = int.Parse(reader[6]);
        //giocatore.Livello_attuale = int.Parse(reader[7]);
        //giocatore.Esperienza_attuale = int.Parse(reader[8]);
        //giocatore.Esperienza_livello_successivo = int.Parse(reader[9]);
        //giocatore.Vite = int.Parse(reader[10]);

        return giocatore;
    }

    public string DatiNemiciFormat()
    {
        string dati_nemici = "";
        return dati_nemici;
    }

    public List<GameObject> DatiNemiciDeformat(string dati)
    {
        List<GameObject> nemici = new List<GameObject>();
        return nemici;
    }

    public string DatiLivelloFormat()
    {
        string dati_livello = "";
        return dati_livello;
    }

    public List<GameObject> DatiLivelloDeformat(string dati)
    {
        List<GameObject> livello = new List<GameObject>();
        return livello;
    }

    public string DatiInventarioFormat()
    {
        string dati_inventario = "";
        return dati_inventario;
    }

    public List<GameObject> DatiInventarioDeformat(string dati)
    {
        List<GameObject> inventario = new List<GameObject>();
        return inventario;
    }
}