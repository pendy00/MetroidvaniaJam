public class Weapon : Equipable
{
    private void Awake()
    {
        this.Game_Item_Type = GAME_ITEM_TYPE.WEAPON;
    }
}