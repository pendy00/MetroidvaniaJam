using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private GameItemUI game_item;

    private PlayerInputController player_input_controller;
    private PlayerInventoryController inventory_controller;


    public void Init(PlayerInputController player_input_controller, PlayerInventoryController inventory_controller)
    {
        this.player_input_controller = player_input_controller;
        this.inventory_controller = inventory_controller;
    }

    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            if (game_item)
            {
                inventory_controller.AddItem(game_item.Game_item);
                game_item.Collect();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
            game_item = collision.gameObject.GetComponent<GameItemUI>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        game_item = null;
    }
}