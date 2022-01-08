using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    private PlayerLifeBeatUI player_life_beat_ui;
    private PlayerUIExpBar exp_bar_ui;
    private PlayerUILives lives_ui;
    private PlayerUILevel level_ui;

    public PlayerLifeBeatUI Player_Life_Beat_UI { get => player_life_beat_ui; set => player_life_beat_ui = value; }
    public PlayerUIExpBar Exp_bar_ui { get => exp_bar_ui; set => exp_bar_ui = value; }
    public PlayerUILives Lives_ui { get => lives_ui; set => lives_ui = value; }
    public PlayerUILevel Level_ui { get => level_ui; set => level_ui = value; }

    public void Init(PlayerLifeBeatUI lifebeat, PlayerUIExpBar exp, PlayerUILives lives, PlayerUILevel level)
    {
        player_life_beat_ui = lifebeat;
        exp_bar_ui = exp;
        lives_ui = lives;
        level_ui = level;
    }

    //Update player's life point status ui
    public void UpdateLifeBeatUI(int value)
    {
        player_life_beat_ui.UpdatePuntiFeritaUI(value);
    }

    //Update player's exp bar ui
    public void UpdateExpBarUI(float value)
    {
        exp_bar_ui.Exp_Bar.fillAmount = value;
    }

    //Update player's level ui
    public void UpdateLevelUI(int value)
    {
        Level_ui.UpdateLevel(value);
    }

    //Update player's lives ui
    public void UpdateLivesUI(int value)
    {
        lives_ui.UpdateVite(value);
    }

    public void UpdateAllUI(int life_points, int exp_points, int level, int lives)
    {
        UpdateLifeBeatUI(life_points);
        UpdateExpBarUI(exp_points);
        UpdateLevelUI(level);
        UpdateLivesUI(lives);
    }
}