using System.Threading.Tasks;

//timer utilizzato per evitare salvataggi ripetuti ogni update.
public class SavePointTimer
{
    //timer utilizzato per il calcolo del tempo trascorso
    private float delay;
    //timer impostato a valore predefinito da inspector, indica il tempo minimo che deve trascorrere per poter effettuare un nuovo salvataggio
    public float DELAY;
    
    public async void EnableSavePoint(bool save)
    {
        //inizializzaione del timer utilizzato per il calcolo
        delay = DELAY;
        //disabilitazione del salvataggio
        save = false;
        //decremento del timer
        while(delay > 0)
        {
            delay--;
            await Task.Delay(1000);
        }

        //reimpostazione del timer a valore predefinito
        delay = DELAY;

        //riabilitazione del salvataggio
        save = true; ;
    }
}