using UnityEngine;
using UnityEngine.UI;

public class PlayerUIForza : MonoBehaviour
{
    private Text forza_ui;
    private const string forza_text = "Forza: ";

    public Text Forza_ui { get => forza_ui; set => forza_ui = value; }

    private void Start()
    {
        forza_ui = GetComponent<Text>();
    }

    public void UpdateForzaUI(int value)
    {
        forza_ui.text = forza_text + value;
    }
}