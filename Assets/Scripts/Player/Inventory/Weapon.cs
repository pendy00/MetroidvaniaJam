public class Weapon : GameItem
{
    private int livello;
    private int forza;
    private int costituzione;
    private int fortuna;

    private bool equipped;

    public int Livello { get => livello; set => livello = value; }
    public int Forza { get => forza; set => forza = value; }
    public int Costituzione { get => costituzione; set => costituzione = value; }
    public int Fortuna { get => fortuna; set => fortuna = value; }

    public bool Equipped { get => equipped; set => equipped = value; }

    private void Start()
    {
        this.Game_Item_Type = GAME_ITEM_TYPE.WEAPON;
    }
}