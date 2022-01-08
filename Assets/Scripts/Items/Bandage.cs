public class Bandage : CollectableObject
{
    private const string item_name = "bandage";
    public int item_quantity;

    private void Awake()
    {
        Collectable_values = new Collectable(item_name, item_quantity);
    }
}