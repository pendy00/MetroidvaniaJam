using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerLifeBar life_bar;
    private PlayerUILifeBar life_bar_ui;

    private PlayerExpBar exp_bar;
    private PlayerUIExpBar exp_bar_ui;

    private PlayerLives lives;
    private PlayerUILives lives_ui;

    private PlayerLevel level;
    private PlayerUILevel level_ui;

    public PlayerLifeBar Life_bar { get => life_bar; set => life_bar = value; }
    public PlayerUILifeBar Life_bar_ui { get => life_bar_ui; set => life_bar_ui = value; }
    public PlayerExpBar Exp_bar { get => exp_bar; set => exp_bar = value; }
    public PlayerUIExpBar Exp_bar_ui { get => exp_bar_ui; set => exp_bar_ui = value; }
    public PlayerLives Lives { get => lives; set => lives = value; }
    public PlayerUILives Lives_ui { get => lives_ui; set => lives_ui = value; }
    public PlayerLevel Level { get => level; set => level = value; }
    public PlayerUILevel Level_ui { get => level_ui; set => level_ui = value; }

    private void Start()
    {
        life_bar = FindObjectOfType<PlayerLifeBar>();
        life_bar_ui = FindObjectOfType<PlayerUILifeBar>();

        exp_bar = FindObjectOfType<PlayerExpBar>();
        exp_bar_ui = FindObjectOfType<PlayerUIExpBar>();

        lives = FindObjectOfType<PlayerLives>();
        lives_ui = FindObjectOfType<PlayerUILives>();

        level = FindObjectOfType<PlayerLevel>();
        level_ui = FindObjectOfType<PlayerUILevel>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        life_bar_ui.Life_Bar.fillAmount = life_bar.EnergiaAttualePercentuale();
        exp_bar_ui.Exp_Bar.fillAmount = exp_bar.EsperienzaAttualePercentuale();
        lives_ui.UpdateVite(lives.Vite_attuale);
        level_ui.UpdateLivello(level.Livello_attuale);
    }

    public void UpdateLifeBarUI(float value)
    {
        life_bar.UpdateEnergiaAttuale(value, lives);
        life_bar_ui.Life_Bar.fillAmount = life_bar.EnergiaAttualePercentuale();

        lives_ui.UpdateVite(lives.Vite_attuale);
    }

    public void UpdateExpBar(float value)
    {
        exp_bar.UpdateEsperienzaAttuale(value, level);
        exp_bar_ui.Exp_Bar.fillAmount = exp_bar.EsperienzaAttualePercentuale();

        level_ui.UpdateLivello(level.Livello_attuale);
    }

    public void UpdateLives(int value)
    {
        lives.UpdateViteAttuale(value);
        lives_ui.UpdateVite(lives.Vite_attuale);

        //check game over
    }

    public void UpdateLevel(int value)
    {
        level.UpdateLivelloAttuale(value);

    }
}