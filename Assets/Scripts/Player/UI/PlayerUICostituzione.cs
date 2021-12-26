using UnityEngine;
using UnityEngine.UI;

public class PlayerUICostituzione : MonoBehaviour
{
    private Text costituzione_ui;
    private const string costituzione_text = "Costituzione: ";

    public Text Costituzione_ui { get => costituzione_ui; set => costituzione_ui = value; }

    private void Start()
    {
        costituzione_ui = GetComponent<Text>();
    }

    public void UpdateCostituzioneUI(int value)
    {
        costituzione_ui.text = costituzione_text + value;
    }
}