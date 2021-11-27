using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerUILifeBar life_bar_ui;

    private PlayerUIExpBar exp_bar_ui;

    private PlayerUILives lives_ui;

    private PlayerUILevel level_ui;

    public PlayerUILifeBar Life_bar_ui { get => life_bar_ui; set => life_bar_ui = value; }
    public PlayerUIExpBar Exp_bar_ui { get => exp_bar_ui; set => exp_bar_ui = value; }
    public PlayerUILives Lives_ui { get => lives_ui; set => lives_ui = value; }
    public PlayerUILevel Level_ui { get => level_ui; set => level_ui = value; }

    private void Start()
    {
        life_bar_ui = FindObjectOfType<PlayerUILifeBar>();

        exp_bar_ui = FindObjectOfType<PlayerUIExpBar>();

        lives_ui = FindObjectOfType<PlayerUILives>();

        level_ui = FindObjectOfType<PlayerUILevel>();
    }

    //Update all the player's UI
    public void UpdateUI(float life_value, float exp_value, int lives_values, int level_value)
    {
        life_bar_ui.Life_Bar.fillAmount = life_value;
        exp_bar_ui.Exp_Bar.fillAmount = exp_value;
        lives_ui.UpdateVite(lives_values);
        level_ui.UpdateLevel(level_value);
    }

    //Update player's life bar ui
    public void UpdateLifeBarUI(float value)
    {
        life_bar_ui.Life_Bar.fillAmount = value;
    }

    //Update player's exp bar ui
    public void UpdateExpBarUI(float value)
    {
        exp_bar_ui.Exp_Bar.fillAmount = value;
    }

    //Update player's lives ui
    public void UpdateLivesUI(int value)
    {
        lives_ui.UpdateVite(value);

        //check game over
    }

    //Update player's level ui
    public void UpdateLevelUI(int value)
    {
        Level_ui.UpdateLevel(value);
    }
}