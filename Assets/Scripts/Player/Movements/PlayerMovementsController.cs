using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementsController : MonoBehaviour
{
    //movemnts parameters
    public float walking_speed;
    public float running_speed;
    public float jump_strenght;
    private float airborne_speed;

    //classes that interacts with player movements
    private PlayerMovements player_movements;
    private PlayerAnimationsController player_animations_controller;

    //input from player
    private PlayerInputController player_input_controller;
    private PlayerFXController player_fx_controller;

    public void Init(PlayerMovements player_movements, PlayerAnimationsController player_animations_controller, PlayerFXController player_fx_controller, PlayerInputController player_input_controller)
    {
        this.player_movements = player_movements;
        this.player_animations_controller = player_animations_controller;
        this.player_input_controller = player_input_controller;
        this.player_fx_controller = player_fx_controller;


        airborne_speed = walking_speed;
    }

    public void Update()
    {
        if (player_movements.Is_grounded)
        {
            Idle(); //reset player animation to idle

            if (player_input_controller.Player_input.Down)
            {
                Crouch();

                if (player_input_controller.Player_input.Right)
                    Crouch(Vector3.right);
                if (player_input_controller.Player_input.Left)
                    Crouch(Vector3.left);
            }
            else
            {
                //make player run
                if (player_input_controller.Player_input.Run)
                {
                    if (player_input_controller.Player_input.Right)
                        Run(Vector3.right);

                    if (player_input_controller.Player_input.Left)
                        Run(Vector3.left);

                    airborne_speed = running_speed;
                }
                else //make player walk
                {
                    if (player_input_controller.Player_input.Right)
                        Walk(Vector3.right);
                    if (player_input_controller.Player_input.Left)
                        Walk(Vector3.left);

                    airborne_speed = walking_speed;
                }
            }

            if (player_input_controller.Player_input.Jump)
                Jump(); //make player jump
        }
        else
        {
            if (player_input_controller.Player_input.Right)
                JumpMove(Vector3.right, airborne_speed);

            if (player_input_controller.Player_input.Left)
                JumpMove(Vector3.left, airborne_speed);
        }

        player_animations_controller.FallingSpeed(player_movements.Falling_speed.y);

    }

    //activate idle animation and fx
    public void Idle()
    {
        player_animations_controller.Idle();
        player_fx_controller.IdleFX();
    }

    //activate walking movemnts, animations and fx
    public void Walk(Vector3 direction)
    {
        player_movements.MovePlayer(direction, walking_speed);
        player_animations_controller.Walk();
        player_fx_controller.WalkFX();
    }

    //activate running movements, animations and fx
    public void Run(Vector3 direction)
    {
        player_movements.MovePlayer(direction, running_speed);
        player_animations_controller.Run();
        player_fx_controller.RunFX();
    }

    public void JumpMove(Vector3 direction, float airborne_speed)
    {
        player_movements.MovePlayerAirborne(direction, airborne_speed);
    }

    //activates jumping movements, animations and fx
    public void Jump()
    {
        player_movements.Jump(jump_strenght);
        player_animations_controller.Jump();
        player_fx_controller.JumpFX();
    }

    //activate crouching animations and fx
    public void Crouch(Vector3 direction)
    {
        player_movements.LookAtDirection(direction.x);
    }

    public void Crouch()
    {
        player_animations_controller.Crouch();
        player_fx_controller.CrouchFX();
    }
}