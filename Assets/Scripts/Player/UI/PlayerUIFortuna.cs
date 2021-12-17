using UnityEngine;
using UnityEngine.UI;

public class PlayerUIFortuna : MonoBehaviour
{
    private Text fortuna_ui;
    private const string fortuna_text = "Fortuna: ";

    public Text Fortuna_ui { get => fortuna_ui; set => fortuna_ui = value; }

    private void Start()
    {
        fortuna_ui = GetComponent<Text>();
    }

    public void UpdateFortunaUI(int value)
    {
        fortuna_ui.text = fortuna_text + value;
    }
}