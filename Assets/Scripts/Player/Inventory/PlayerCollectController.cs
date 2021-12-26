using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private Collectable collectable;

    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;

    public Collectable Collectable { get => collectable; set => collectable = value; }

    public void Init(PlayerInputController player_input_controller, InventoryController inventory_controller)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;

        collectable = null;
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            if (collectable)
            {
                inventory_controller.AddItem(collectable);
                collectable.Collect();
                collectable = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("collectable"))
            collectable = collision.GetComponent<Collectable>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collectable = null;
    }
}