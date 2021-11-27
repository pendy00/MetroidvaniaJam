public class Armor : Equipable
{
    public enum ARMOR_ITEM_TYPE { HEAD, CHEST, GLOVES, ACCESSORY, BOTTOM, SHOES}

    private ARMOR_ITEM_TYPE armor_item_type;

    public ARMOR_ITEM_TYPE Armor_Item_Type { get => armor_item_type; set => armor_item_type = value; }

    private void Awake()
    {
        this.Game_Item_Type = GAME_ITEM_TYPE.ARMOR;
    }
}