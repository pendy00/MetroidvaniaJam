using System.Collections;
using UnityEngine;

//change player position when she interacts with the doors and play 
public class DoorController : MonoBehaviour
{
    private GameObject player;

    public IEnumerator DoorTransiction(Door door)
    {
        GameStateController gsc = FindObjectOfType<GameStateController>(); //store game state controller in a variable
        gsc.ChangeGameState(GameStateController.GAME_STATE.TRANSICTION); //change game state controller to transiction to disable player controller

        while (!door.Door_opened)
            yield return new WaitForFixedUpdate();

        player = FindObjectOfType<PlayerMovementsController>().gameObject;
        player.transform.position = door.Target_position; //change player position

        //wait for fade duration // change with animation and animation's tim
        while (!door.Transiction_end) //check for animation end
            yield return new WaitForFixedUpdate();

        door.ResetControlValues();

        gsc.ChangeGameState(GameStateController.GAME_STATE.EXPLORING); //resume gameplay
    }
}