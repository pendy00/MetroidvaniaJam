using UnityEngine;
using UnityEngine.UI;

public class PlayerUILives : MonoBehaviour
{
    private Text vite_text;

    private void Awake()
    {
        vite_text = GetComponent<Text>();
    }

    public void UpdateVite(int value)
    {
        vite_text.text = "Vite: " + value.ToString();
    }
}