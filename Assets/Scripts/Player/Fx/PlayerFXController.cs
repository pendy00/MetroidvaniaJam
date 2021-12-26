using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFXController : MonoBehaviour
{
    public AudioClip player_idle;
    public AudioClip player_walk;
    public AudioClip player_run;
    public AudioClip player_jump;
    public AudioClip player_crouch;

    private PlayerFX player_fx;

    public PlayerFX Player_fx { get => player_fx; set => player_fx = value; }

    public void Init(PlayerFX player_fx)
    {
        this.player_fx = player_fx;
    }

    public void IdleFX()
    {
        player_fx.PlayAudioClip(player_idle);
    }

    public void WalkFX()
    {
        player_fx.PlayAudioClip(player_walk);
    }

    public void RunFX()
    {
        player_fx.PlayAudioClip(player_run);
    }

    public void JumpFX()
    {
        player_fx.PlayAudioClip(player_jump);
    }

    public void CrouchFX()
    {
        player_fx.PlayAudioClip(player_crouch);
    }
}