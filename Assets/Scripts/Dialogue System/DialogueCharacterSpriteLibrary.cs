using UnityEngine;

public class DialogueCharacterSpriteLibrary : MonoBehaviour
{
    public Sprite cecile_afraid_1;
    public Sprite cecile_serious;
    public Sprite cecile_speech_1;
    public Sprite cecile_speech_2;
    public Sprite cecile_stupor_1;
    public Sprite cecile_stupor_2;
    public Sprite cecile_doubt_1;
    public Sprite cecile_angry_1;
    public Sprite cecile_angry_2;
    public Sprite cecile_angry_3;
    public Sprite cecile_angry_4;
    public Sprite cecile_angry_5;
    public Sprite cecile_jall_1;
    public Sprite cecile_jall_2;
    public Sprite cecile_jall_3;

    public Sprite sebastiano_serious;
    public Sprite sebastiano_speech_1;
    public Sprite sebastiano_speech_2;

    public Sprite GetCharacterSprite(string emoji)
    {
        Sprite temp = null;

        switch (emoji)
        {
            case "cecile_angry_1":
                return cecile_angry_1;
            default:
                return temp;
        }
    }
}