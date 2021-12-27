using System;
public class Collectable
{
    public string item_name;
    public int item_quantity;

    public string Item_name { get => item_name; set => item_name = value; }
    public int Item_quantity { get => item_quantity; set => item_quantity = value; }

    public Collectable() {  }

    public Collectable(string item_name, int item_quantity)
    {
        this.item_name = item_name;
        this.item_quantity = item_quantity;
    }
}