//questo oggetto può essere utilizzato dal giocatore per ottenere degli effetti permanenti
public class Consumable : GameItem
{
    private int quantity;

    public int Quantity { get => quantity; set => quantity = value; }

    private void Awake()
    {
        this.Game_Item_Type = GAME_ITEM_TYPE.CONSUMABLE; //inizializza il tupo di oggetto come CONSUMABILE
    }

    //viene usata quando il personaggio usa un singolo elemento
    public bool UseItemSingle()
    {
        if(quantity > 0)
        {
            quantity--;
            return true;
        }

        return false;
    }

    //viene usata quando il personaggio usa più elementi
    public bool UseItemMultiple(int value)
    {
        if(quantity - value >= 0)
        {
            quantity -= value;
            return true;
        }

        return false;
    }
}