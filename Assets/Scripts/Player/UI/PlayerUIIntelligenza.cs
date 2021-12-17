using UnityEngine;
using UnityEngine.UI;

public class PlayerUIIntelligenza : MonoBehaviour
{
    private Text intelligenza_ui;
    private const string intelligenza_text = "Intelligenza: ";

    public Text Intelligenza_ui { get => intelligenza_ui; set => intelligenza_ui = value; }

    private void Start()
    {
        intelligenza_ui = GetComponent<Text>();
    }

    public void UpdateIntelligenzaUI(int value)
    {
        intelligenza_ui.text = intelligenza_text + value;
    }
}