using UnityEngine;

//gestisce l'interazione fra le varie classi del giocatore
public class PlayerController : MonoBehaviour
{
    private InputController input_controller;
    private PlayerMovements player_movements;
    private PlayerAnimations player_animations;
    private PlayerFx player_fx;

    private void Start()
    {
        input_controller = FindObjectOfType<InputController>();
        player_movements = FindObjectOfType<PlayerMovements>();
        player_animations = FindObjectOfType<PlayerAnimations>();
    }

    //attiva le azioni necessarie in base all'input ricevuto dal'utente
    private void FixedUpdate()
    {
        PlayerIdle();
        print(player_movements.Rb.velocity.x);

        if (input_controller.Up)
        {
            //acces elevetors and doors
        }

        if (input_controller.Right)
            PlayerWalk(Vector3.right);

        if (input_controller.Left)
            PlayerWalk(Vector3.left);

        if (input_controller.Jump)
            PlayerJump();

        if (input_controller.Action)
        {
            //do action based on item
        }

        if (input_controller.Crouch)
            PlayerCrouching();

        if (input_controller.Menu)
        {
            //attiva menu
        }

        if (input_controller.Cancel)
        {
            //cacnella azione
        }

        if (!player_movements.Ground)
            PlayerJump();
    }

    //azioni effetuate quando il personaggio � fermo (idle)
    public void PlayerIdle()
    {
        player_animations.Idle();
    }

    //azioni effettuate quando il personaggio cammina
    public void PlayerWalk(Vector3 direction)
    {
        player_movements.MovePlayer(direction);
        player_animations.Walking(player_movements.Rb.velocity.x);
    }

    //azioni effetuate quando il personaggio salta
    public void PlayerJump()
    {
        player_movements.Jump();
        player_animations.Jumping();
    }

    //azioni effettuate quando il personaggio si accovaccia
    public void PlayerCrouching()
    {
            player_animations.Crouching();
    }
}