using System.Collections;
using UnityEngine;

//change player position when she interacts with the doors
public class DoorController : MonoBehaviour
{
    public IEnumerator DoorTransiction(Door door)
    {
        GameStateController gsc = FindObjectOfType<GameStateController>(); //store game state controller in a variable
        gsc.ChangeGameState(GameStateController.GAME_STATE.TRANSICTION); //change game state controller to transiction to disable player controller

        while (!door.Door_opened)
            yield return new WaitForEndOfFrame();

        GameObject player = FindObjectOfType<PlayerMovementsController>().gameObject; // find player
        player.transform.position = door.Target_position; //change player position

        //wait for fade duration // change with animation and animation's time
        while (!door.Transiction_end) //check for animation end
            yield return new WaitForEndOfFrame();

        door.ResetControlValues();

        gsc.ChangeGameState(GameStateController.GAME_STATE.EXPLORING); //resume gameplay
    }
}