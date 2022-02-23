using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<string> dialogues;
    private int index;

    public List<string> Dialogues { get => dialogues; set => dialogues = value; }

    public string GetNextDialogue()
    {
        if(index < dialogues.Count)
        {
            string temp = dialogues[index];
            index++;
            return temp;
        }

        return null;
    }

    public void ResetDialogue()
    {
        index = 0;
    }
}