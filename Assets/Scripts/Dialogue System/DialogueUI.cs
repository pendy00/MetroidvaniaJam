using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Canvas dialogue_canvas;
    public Image character_image;
    public Text dialogue_text;

    public void UpdateCharacteImage(Sprite s)
    {
        character_image.sprite = s;
    }

    public void UpdateDialogueText(string t)
    {
        dialogue_text.text = t;
    }

    public void ClearDialogueText()
    {
        dialogue_text.text = "";
    }

    public void ShowUI(bool value)
    {
        dialogue_canvas.gameObject.SetActive(value);
    }
}