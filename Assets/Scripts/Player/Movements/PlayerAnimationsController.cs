using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    //animator parameters name
    private const string idle_animation = "idle";
    private const string walk_animation = "walk";
    private const string run_animation = "run";
    private const string jump_animation = "jump";
    private const string crouch_animation = "crouch";
    private const string fallig_speed = "falling speed";

    private PlayerAnimations player_animations;

    public void Init(PlayerAnimations player_animations)
    {
        this.player_animations = player_animations;
    }

    public void Idle()
    {
        player_animations.SetBool(idle_animation, true);
        player_animations.SetBool(walk_animation, false);
        player_animations.SetBool(run_animation, false);
        player_animations.SetBool(jump_animation, false);
        player_animations.SetBool(crouch_animation, false);
    }

    public void Walk()
    {
        player_animations.SetBool(idle_animation, false);
        player_animations.SetBool(walk_animation, true);
        player_animations.SetBool(run_animation, false);
        player_animations.SetBool(jump_animation, false);
        player_animations.SetBool(crouch_animation, false);
    }

    public void Run()
    {
        player_animations.SetBool(idle_animation, false);
        player_animations.SetBool(walk_animation, false);
        player_animations.SetBool(run_animation, true);
        player_animations.SetBool(jump_animation, false);
        player_animations.SetBool(crouch_animation, false);
    }

    public void Jump()
    {
        player_animations.SetBool(idle_animation, false);
        player_animations.SetBool(walk_animation, false);
        player_animations.SetBool(run_animation, false);
        player_animations.SetBool(jump_animation, true);
        player_animations.SetBool(crouch_animation, false);
    }

    public void Crouch()
    {
        player_animations.SetBool(idle_animation, false);
        player_animations.SetBool(walk_animation, false);
        player_animations.SetBool(run_animation, false);
        player_animations.SetBool(jump_animation, false);
        player_animations.SetBool(crouch_animation, true);
    }

    public void FallingSpeed(float falling_speed)
    {
        player_animations.SetFloat(fallig_speed, falling_speed);
    }
}