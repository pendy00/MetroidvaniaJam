using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystemController : MonoBehaviour
{
    private InputController input_controller;

    private DialogueSystem dialogue;
    private DialogueUI dialogue_ui;

    private bool can_show_next;
    private bool dialogue_end;

    public DialogueSystem Dialogue { get => dialogue; set => dialogue = value; }
    public DialogueUI Dialogue_UI { get => dialogue_ui; set => dialogue_ui = value; }

    //eliminare e gestire con game manager una volta implementato
    private void Start()
    {
        input_controller = FindObjectOfType<InputController>();
        dialogue = FindObjectOfType<DialogueSystem>();
        dialogue_ui = FindObjectOfType<DialogueUI>();
        can_show_next = false;
        dialogue_end = false;
    }

    private void Update()
    {
        if (input_controller.Action && !dialogue_end && can_show_next)
            ShowNextText();

        if(input_controller.Action && dialogue_end)
        {
            //close all dialogue system and dialogue iteractions
            dialogue_ui.ShowUI(false);
        }
    }

    public void ShowNextText()
    {
        string temp = dialogue.GetNextDialogue();
        if(temp != null)
            dialogue_ui.ShowNextDialogue(temp);
        else
            dialogue_end = true;

        can_show_next = true;
    }

    public void StartDialogue()
    {
        dialogue_ui.ShowUI(true);
        ShowNextText();
    }
}