using UnityEngine;
using UnityEngine.UI;

public class PlayerUIExpBar : MonoBehaviour
{
    private Image expbar;

    public Image Exp_Bar { get => expbar; }

    private void Awake()
    {
        expbar = GetComponent<Image>();
    }

    public void Show(bool value)
    {
        expbar.enabled = value;
    }

    public void UpdateExpBar(int value)
    {
        float x = value / 100;
    }
}