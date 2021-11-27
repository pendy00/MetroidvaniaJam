using UnityEngine;

//questa classe definisce le caratteristiche principali di un oggetto all'interno del gioco
public class GameItem : MonoBehaviour
{
    public enum GAME_ITEM_TYPE { CONSUMABLE, WEAPON, ARMOR, KEY_OBJECT};

    private string game_item_name; //nome dell'oggetto all'interno del gioco
    private GAME_ITEM_TYPE game_item_type; //definisce il tipo di oggetto

    public string Game_item_name { get => game_item_name; set => game_item_name = value; }
    public GAME_ITEM_TYPE Game_Item_Type { get => game_item_type; set => game_item_type = value; }
}