using UnityEngine;
using UnityEngine.UI;

public class PlayerUIStats : MonoBehaviour
{
    public Image player_stats_card;
    public Image player_portrait;

    private PlayerLifeBeatUI player_life_beat_ui;
    private PlayerUIExpBar exp_bar_ui;
    private PlayerUILives lives_ui;
    private PlayerUILevel level_ui;

    private PlayerUIForza forza_ui;
    private PlayerUICostituzione costituzione_ui;
    private PlayerUIIntelligenza intelligenza_ui;
    private PlayerUIFortuna fortuna_ui;

    public PlayerLifeBeatUI Player_Life_Beat_UI { get => player_life_beat_ui; set => player_life_beat_ui = value; }
    public PlayerUIExpBar Exp_bar_ui { get => exp_bar_ui; set => exp_bar_ui = value; }
    public PlayerUILives Lives_ui { get => lives_ui; set => lives_ui = value; }
    public PlayerUILevel Level_ui { get => level_ui; set => level_ui = value; }
    public PlayerUIForza Forza_ui { get => forza_ui; set => forza_ui = value; }
    public PlayerUICostituzione Costituzione_ui { get => costituzione_ui; set => costituzione_ui = value; }
    public PlayerUIIntelligenza Intelligenza_ui { get => intelligenza_ui; set => intelligenza_ui = value; }
    public PlayerUIFortuna Fortuna_ui { get => fortuna_ui; set => fortuna_ui = value; }

    public void Init(PlayerLifeBeatUI lifebeat, PlayerUIExpBar exp, PlayerUILives lives, PlayerUILevel level,
                    PlayerUIForza forza, PlayerUICostituzione costituzione, PlayerUIIntelligenza intelligenza, PlayerUIFortuna fortuna)
    {

        player_life_beat_ui = lifebeat;
        exp_bar_ui = exp;
        lives_ui = lives;
        level_ui = level;
        forza_ui = forza;
        costituzione_ui = costituzione;
        intelligenza_ui = intelligenza;
        fortuna_ui = fortuna;
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

    public void UpdateForzaUI(int value)
    {
        forza_ui.UpdateForzaUI(value);
    }

    public void UpdateCostituzioneUI(int value)
    {
        costituzione_ui.UpdateCostituzioneUI(value);
    }

    public void UpdateIntelligenzaUI(int value)
    {
        intelligenza_ui.UpdateIntelligenzaUI(value);
    }

    public void UpdateFortunaUI(int value)
    {
        fortuna_ui.UpdateFortunaUI(value);
    }

    //show stats in the menu tab
    public void ShowUIStats(bool value)
    {
        player_stats_card.color = value ? new Color(255, 255, 255, 255) : new Color(255, 255, 255, 0);
        player_portrait.color = value ? new Color(255, 255, 255, 255) : new Color(255, 255, 255, 0);
        forza_ui.Forza_ui.color = value ? new Color(0, 0, 0, 255) : new Color(0, 0, 0, 0);
        costituzione_ui.Costituzione_ui.color = value ? new Color(0, 0, 0, 255) : new Color(0, 0, 0, 0);
        intelligenza_ui.Intelligenza_ui.color = value ? new Color(0, 0, 0, 255) : new Color(0, 0, 0, 0);
        fortuna_ui.Fortuna_ui.color = value ? new Color(0, 0, 0, 255) : new Color(0, 0, 0, 0);
    }
}