// set scene item as a whip item
public class Whip : EquipableUI
{
    public void Start()
    {
        Game_item.Item_name = "whip";
        Game_item.Item_quantity = 1;   
    }
}