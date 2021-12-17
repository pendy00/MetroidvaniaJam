using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    private InputController input_controller;
    private PlayerUIStats player_ui_stats;

    public void Init(InputController input, PlayerUIStats puis)
    {
        input_controller = input;
        player_ui_stats = puis;
    }
    private void Update()
    {
        if (input_controller.Cancel)
        {
            player_ui_stats.ShowUIStats(false);
            FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
        }
    }
}