using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    private Player player;
    private PlayerLife player_life;
    private PlayerExp player_exp;
    private PlayerLives player_lives;
    private PlayerLevel player_level;
    private PlayerUIController player_ui_controller;


    public PlayerUIController Player_ui_controller { get => player_ui_controller; set => player_ui_controller = value; }
    public PlayerLife Player_life { get => player_life; set => player_life = value; }
    public PlayerExp Player_exp { get => player_exp; set => player_exp = value; }
    public PlayerLives Player_lives { get => player_lives; set => player_lives = value; }
    public PlayerLevel Player_level { get => player_level; set => player_level = value; }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player_life = FindObjectOfType<PlayerLife>();
        player_exp = FindObjectOfType<PlayerExp>();
        player_lives = FindObjectOfType<PlayerLives>();
        player_level = FindObjectOfType<PlayerLevel>();
        player_ui_controller = FindObjectOfType<PlayerUIController>();
    }

    public void UpdatePlayerLife(float value)
    {
        player_life.UpdateEnergiaAttuale(value, player_lives);
        player_ui_controller.UpdateLifeBarUI(player_life.EnergiaAttualePercentuale());
    }

    public void UpdatePlayerExp(float value) 
    {
        player_exp.UpdateEsperienzaAttuale(value, player_level);
        player_ui_controller.UpdateExpBarUI(player_exp.EsperienzaAttualePercentuale());
    }

    public void UpdatePlayerLives(int value)
    {
        player_lives.UpdateViteAttuale(value);
        player_ui_controller.UpdateLivesUI(player_lives.Vite_attuale);
        //check for game over
    }

    public void UpdatePlayerLevele(int value)
    {
        player_level.UpdateLivelloAttuale(value);
        player_ui_controller.UpdateLevelUI(player_level.Livello_attuale);
    }

    public void UpdatePlayerStats()
    {
        // Calcolo nuovi parametri tramite formula
    }
}