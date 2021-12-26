using UnityEngine;

public class PlayerItemCollider : MonoBehaviour
{
    private Collectable collectable;
    private Interactable interactable;

    private PlayerInputController player_input_controller;
    private PlayerInventoryController player_inventory_controller;

    public Collectable Collectable { get => collectable; set => collectable = value; }
    public Interactable Interactable { get => interactable; set => interactable = value; }

    public void Init(PlayerInputController player_input_controller, PlayerInventoryController player_inventory_controller)
    {
        this.player_input_controller = player_input_controller;
        this.player_inventory_controller = player_inventory_controller;
    }

    private void Awake()
    {
        player_input_controller = FindObjectOfType<PlayerInputController>();
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            if(collectable != null)
            {
                FindObjectOfType<InventoryController>().AddItem(collectable);
                //collectable.Collect();
                collectable = null;
            }

            if(interactable != null)
            {
                interactable.Action();
                interactable = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("collectable"))
            collectable = collision.gameObject.GetComponent<Collectable>();

        if (collision.gameObject.tag.Equals("interactable"))
            interactable = collision.gameObject.GetComponent<Interactable>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collectable = null;
        interactable = null;
    }
}