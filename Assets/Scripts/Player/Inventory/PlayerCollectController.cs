using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private CollectableObject collectable_object;

    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;


    public void Init(PlayerInputController player_input_controller, InventoryController inventory_controller)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            if (collectable_object)
            {
                inventory_controller.AddItem(collectable_object.Collectable_values);
                collectable_object.Collect();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("collectable"))
            collectable_object = collision.gameObject.GetComponent<CollectableObject>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collectable_object = null;
    }
}