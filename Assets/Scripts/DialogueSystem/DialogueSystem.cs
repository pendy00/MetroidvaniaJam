using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public List<string> dialogo;
    private int cursore = 0;
    public List<string> Dialog { get => dialogo; set => dialogo = value; }
    public string GetNextDialogue()
    {
        string temp = null;

        if (cursore < dialogo.Count)
        {
            temp = dialogo[cursore];
            cursore++;
        }
        
        return temp;
    }
}