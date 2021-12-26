using UnityEngine;
using UnityEngine.UI;

public class PlayerUILevel : MonoBehaviour
{
    private Text livello_text;

    private void Awake()
    {
        livello_text = GetComponent<Text>();
    }

    public void UpdateLevel(int value)
    {
        livello_text.text = "Livello: " + value.ToString();
    }
}