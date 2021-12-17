using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAnimations : MonoBehaviour
{
    protected Animator anim;

    protected const string idle = "idle";
    protected const string walking = "walking";
    protected const string attack_punch = "attack punch";
    protected const string attack_club = "attack club";
    protected const string hit = "hurt";
    protected const string ko = "ko";

    public Animator Anim { get => anim; set => anim = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public abstract void Idle();
    public abstract void Walking();
    public abstract void AttackPunch();
    public abstract void AttackClub();
    public abstract void Hit();
    public abstract void ResetHit();
    public abstract void KO();
}
