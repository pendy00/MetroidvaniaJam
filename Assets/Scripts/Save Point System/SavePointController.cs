using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gestisce le operazioni necessario di acquisizione dati e di controllo per effettuare il salvataggio dei dati
public class SavePointController : MonoBehaviour
{
    private bool is_save_enable; //abilita/disabilita il salvataggio dei dati
    private SavePointTimer save_point_timer; //utilizzato per evitare di salvare i dati troppo di frequentare ed evitare quindi sovraccarico computazionale
    private SavePointConfig save_point_config; //configurazione di salvataggio nei playerpref, utilizzato anche per le effettive operazione di caricamento/salvataggio
    private SavePointDataFormatter save_point_formatter; //formatta i dati acquisiti al momento della richiesta di salvataggio
    public bool Is_Save_Enable { get => is_save_enable; set => is_save_enable = value; }

    private void Start()
    {
        //Inizializzazione degli script utilizzati per il salvataggio
        save_point_timer = new SavePointTimer();
        save_point_config = new SavePointConfig();
        save_point_formatter = new SavePointDataFormatter();
    }

    //salva il gioco allo stato corrente
    public void SaveGame()
    {
        if (is_save_enable)
        {
            save_point_timer.EnableSavePoint(Is_Save_Enable);

            save_point_config.SaveData
                (save_point_formatter.DatiGiocatoreFormat(), save_point_formatter.DatiNemiciFormat(), 
                                        save_point_formatter.DatiLivelloFormat(), save_point_formatter.DatiInventarioFormat());
        }
    }

    // carica il gioco allo stato corrente
    public void LoadGame()
    {
        Player giocatore_temp = save_point_formatter.DatiGiocatoreDeformat(save_point_config.Dati_Giocatore);
        List<GameObject> nemici_temp = save_point_formatter.DatiNemiciDeformat(save_point_config.Dati_Nemici);
        List<GameObject> livello_temp = save_point_formatter.DatiLivelloDeformat(save_point_config.Dati_Livello);
        List<GameObject> inventario_temp = save_point_formatter.DatiInventarioDeformat(save_point_config.Dati_Inventario);

        //@TODO Instaziamento e popolazione di tutti i componenti caricati
    }
}