using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Animations : EnemyAnimations
{
    public override void Idle()
    {
        anim.SetBool(idle, true);
        anim.SetBool(walking, false);
        anim.SetBool(attack_punch, false);
        anim.SetBool(attack_club, false);
        anim.SetBool(hit, false);
        anim.SetBool(ko, false);
    }

    public override void Walking()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, true);
        anim.SetBool(attack_punch, false);
        anim.SetBool(attack_club, false);
        anim.SetBool(hit, false);
        anim.SetBool(ko, false);
    }

    public override void AttackPunch()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(attack_punch, true);
        anim.SetBool(attack_club, false);
        anim.SetBool(hit, false);
        anim.SetBool(ko, false);
    }

    public override void AttackClub()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(attack_punch, false);
        anim.SetBool(attack_club, true);
        anim.SetBool(hit, false);
        anim.SetBool(ko, false);
    }

    public override void Hit()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(attack_punch, false);
        anim.SetBool(attack_club, false);
        anim.SetBool(hit, true);
        anim.SetBool(ko, false);
    }

    public override void ResetHit()
    {
        Idle();
    }

    public void ResetPunch()
    {
        Idle();
    }
    public override void KO()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(attack_punch, false);
        anim.SetBool(attack_club, false);
        anim.SetBool(hit, false);
        anim.SetBool(ko, true);
    }
}