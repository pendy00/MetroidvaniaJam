using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private PlayerInput player_input;
    private Dialogue dialogue;
    private DialogueUI dialogue_ui;

    public bool is_enable;

    private void Start()
    {
        player_input = FindObjectOfType<PlayerInputController>().Player_input;
        dialogue = GetComponent<Dialogue>();
        dialogue_ui = GetComponentInChildren<DialogueUI>();
        ShowUI(false);
    }

    public IEnumerator DialogueSequence()
    {
        ShowUI(true);
        string temp = dialogue.GetNextDialogue();

        while (temp != null)
        {
            string[] s = temp.Split('£');
            string emoji = GetEmoji(s[0]);
            dialogue_ui.UpdateCharacteImage(FindObjectOfType<DialogueCharacterSpriteLibrary>().GetCharacterSprite(emoji));
            dialogue_ui.UpdateDialogueText(s[1]);
            yield return new WaitForEndOfFrame();

            while (!player_input.Action)
                yield return new WaitForEndOfFrame();

            temp = dialogue.GetNextDialogue();
        }

        ShowUI(false);
        yield return new WaitForEndOfFrame();
        FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
        Destroy(this.gameObject);
    }

    public string GetEmoji(string s)
    {
        switch (s)
        {
            case "cecile:-<":
                return "cecile_angry_1";
            default:
                return null;
        }
    }

    public void ShowUI(bool value)
    {
        dialogue_ui.ShowUI(value);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (is_enable)
        {
            if (collision.gameObject.CompareTag("player"))
            {
                FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.DIALOGUE);
                StartCoroutine(DialogueSequence());
            }
        }
    }
}