using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBeatUI : MonoBehaviour
{
    public List<Sprite> life_beat_states;
    private Image life_beat_ui;

    private void Awake()
    {
        life_beat_ui = GetComponent<Image>();
    }

    public void UpdatePuntiFeritaUI(int value)
    {
        if (value <= 100)
            life_beat_ui.sprite = life_beat_states[0];

        if (value <= 60)
            life_beat_ui.sprite = life_beat_states[1];

        if (value <= 40)
            life_beat_ui.sprite = life_beat_states[2];

        if (value <= 20)
            life_beat_ui.sprite = life_beat_states[3];

        if (value <= 0)
            life_beat_ui.sprite = life_beat_states[4];
    }
}