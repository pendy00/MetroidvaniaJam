using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    private PlayerStats player_stats;
    private PlayerUIStats player_ui_stats;

    public PlayerStats Player_Stats { get => player_stats; set => player_stats = value; }
    public PlayerUIStats Player_ui_stats { get => player_ui_stats; set => player_ui_stats = value; }

    public void Init(PlayerStats ps, PlayerUIStats psui, PlayerLifePoints plf,PlayerLifeBeatUI plbui, PlayerExp pe, PlayerUIExpBar peui,
                    PlayerLevel plevel, PlayerUILevel plevelui, PlayerLives plives, PlayerUILives plivesui)
    {
        player_stats = ps;
        player_ui_stats = psui;

        player_stats.Player_life_points = plf;
        player_stats.Player_exp = pe;
        player_stats.Player_level = plevel;
        player_stats.Player_lives = plives;

        player_ui_stats.Player_Life_Beat_UI = plbui;
        player_ui_stats.Exp_bar_ui = peui;
        player_ui_stats.Level_ui = plevelui;
        player_ui_stats.Lives_ui = plivesui;

        player_stats.InitializeValues();
    }

    public void UpdatePlayerLifePoints(int value)
    {
        player_stats.Player_life_points.UpdateLifePoints(value, player_stats.Player_lives);
        player_ui_stats.Player_Life_Beat_UI.UpdatePuntiFeritaUI(player_stats.Player_life_points.Punti_ferita_attuali);
    }

    public void UpdatePlayerExp(int value) 
    {
        player_stats.Player_exp.UpdateEsperienzaAttuale(value, player_stats);
        player_ui_stats.UpdateExpBarUI(player_stats.Player_exp.EsperienzaAttualePercentuale());
    }

    public void UpdatePlayerLives(int value)
    {
        player_stats.Player_lives.UpdateViteAttuale(value);
        player_ui_stats.UpdateLivesUI(player_stats.Player_lives.Vite_attuale);

        if (player_stats.Player_lives.Vite_attuale <= 0)
            FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.DEATH);
        
    }

    public void UpdatePlayerLevel(int value)
    {
        player_stats.Player_level.UpdateLivelloAttuale(value, player_stats);
        player_ui_stats.UpdateLevelUI(player_stats.Player_level.Livello_attuale);
    }

    public void ShowStatsCard(bool value)
    {
        player_ui_stats.UpdateUIValues(player_stats);
        player_ui_stats.ShowUIStats(value);
    }
}