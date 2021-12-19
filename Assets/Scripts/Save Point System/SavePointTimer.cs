using System;
using System.Collections;
using UnityEngine;

//timer utilizzato per evitare salvataggi ripetuti ogni update.
public class SavePointTimer
{
    //timer utilizzato per il calcolo del tempo trascorso
    private int delay;
    //timer impostato a valore predefinito da inspector, indica il tempo minimo che deve trascorrere per poter effettuare un nuovo salvataggio
    public int DELAY;
    
    public IEnumerator EnableSavePoint(bool save)
    {
        //inizializzaione del timer utilizzato per il calcolo
        delay = DELAY;
        //disabilitazione del salvataggio
        save = false;
        //decremento del timer
        for (int i = DELAY; delay > 0; delay--)
            yield return new WaitForSecondsRealtime(1);

        //reimpostazione del timer a valore predefinito
        delay = DELAY;

        //riabilitazione del salvataggio
        save = true; ;
    }
}