using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages game ove
public class GameOver : MonoBehaviour
{
    public Canvas canvas_game_over; // game over canvas

    // TODO manage game over properly
    // shows game over screen and quit application
    public IEnumerator ShowGameOverScreen()
    {
        canvas_game_over.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        Application.Quit();
    }
}