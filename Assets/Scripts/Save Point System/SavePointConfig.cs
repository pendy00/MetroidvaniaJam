using UnityEngine;

//configurazione di stringhe in playerprefs
public class SavePointConfig
{
    private const string datigiocatorekey = "Dati Giocatore"; //chiave utilizzata per salvare i dati giocatore
    private const string datinemicikey = "Dati Nemici"; //chiave utilizzata per salvare i dati dei nemici
    private const string datilivellokey = "Dati Livello"; //chiave utilizzata per salvare i dati relativi al/ai livello/i
    private const string datinventariokey = "Dati Inventario"; //chiave utilizzate per salvare lo stato dell'inventario del giocatore

    //i valori delle chiavi non posso essere modificati
    public string DatiGiocatoreKey { get => datigiocatorekey; }
    public string DatiNemiciKey { get => datinemicikey; }
    public string DatiLivelloKey { get => datilivellokey; }
    public string DatiInventarioKey { get => datinventariokey; }

    //sistema di salvataggio/lettura dei dati
    public string Dati_Giocatore { get => PlayerPrefs.GetString(DatiGiocatoreKey); set => PlayerPrefs.SetString(DatiGiocatoreKey, value); }
    public string Dati_Nemici { get => PlayerPrefs.GetString(DatiNemiciKey); set => PlayerPrefs.SetString(DatiNemiciKey, value); }
    public string Dati_Livello { get => PlayerPrefs.GetString(DatiLivelloKey); set => PlayerPrefs.SetString(DatiLivelloKey, value); }
    public string Dati_Inventario { get => PlayerPrefs.GetString(DatiInventarioKey); set => PlayerPrefs.SetString(DatiInventarioKey, value); }

    

    //inizializza la configurazione delle chiavi in player prefs, se non esistono devono essere create
    public void InitConfig()
    {
        if (!PlayerPrefs.HasKey(DatiGiocatoreKey))
            PlayerPrefs.SetString(DatiGiocatoreKey, "");
        if (!PlayerPrefs.HasKey(DatiNemiciKey))
            PlayerPrefs.SetString(DatiNemiciKey, "");
        if (!PlayerPrefs.HasKey(DatiLivelloKey))
            PlayerPrefs.SetString(DatiLivelloKey, "");
        if (!PlayerPrefs.HasKey(DatiInventarioKey))
            PlayerPrefs.SetString(DatiInventarioKey, "");
    }

    // salva tutti i dati del livello
    public void SaveData(string dati_giocatore, string dati_nemici, string dati_livello, string dati_inventario)
    {
        Dati_Giocatore = dati_giocatore;
        Dati_Nemici = dati_nemici;
        Dati_Livello = dati_livello;
        Dati_Inventario = dati_inventario;
    }
}