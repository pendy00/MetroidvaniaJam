using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public string item_name;
    public enum GAME_ITEM_TYPE { WEAPON, HEALTH_POTION};
    private GAME_ITEM_TYPE item_type;
    public int quantity;
}