using UnityEngine;
using UnityEngine.UI;

public class PlayerUILifeBar : MonoBehaviour
{
    private Image lifebar;

    public Image Life_Bar { get => lifebar; }

    private void Awake()
    {
        lifebar = GetComponent<Image>();
    }

    public void Show(bool value)
    {
        lifebar.enabled = value;
    }

    public void UpdateLifeBar(int value)
    {
        float x = value / 100;
    }
}