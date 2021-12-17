using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    private Text dialogue_text;
    private Image dialogue_image;
    public List<Image> character_icons;
    private int cursor = 0;

    void Start()
    {
        dialogue_text = GetComponent<Text>();
        dialogue_image = GetComponent<Image>();
    }
    

    public void CleanText()
    {
        dialogue_text.text = "";
    }

    public void ShowText(string text)
    {
        dialogue_text.text += text;
    }

    public void ShowNextImage()
    {
        if(cursor < character_icons.Count)
        {
            dialogue_image.sprite = character_icons[cursor].sprite;
            cursor++;
        }
    }

    public void ShowNextDialogue(string text)
    {
        ShowText(text);
        ShowNextImage();
    }

    public void ShowUI(bool value)
    {
        dialogue_text.enabled = value;
        dialogue_image.enabled = value;
    }
}