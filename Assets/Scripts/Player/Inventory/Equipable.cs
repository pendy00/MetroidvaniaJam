public class Equipable : GameItem
{
    private int livello;
    private int energia_massima;
    private int forza;
    private int costituzione;
    private int fortuna;

    private bool equipped;

    public int Energia_Massima { get => energia_massima; set => energia_massima = value; }
    public int Livello { get => livello; set => livello = value; }
    public int Forza { get => forza; set => forza = value; }
    public int Costituzione { get => costituzione; set => costituzione = value; }
    public int Fortuna { get => fortuna; set => fortuna = value; }

    public bool Equipped { get => equipped; set => equipped = value; }
}
