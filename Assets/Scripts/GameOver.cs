using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas canvas_game_over;
    public IEnumerator ShowGameOverScreen()
    {
        canvas_game_over.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        Application.Quit();
    }
}