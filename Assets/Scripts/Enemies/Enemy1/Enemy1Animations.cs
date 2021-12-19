using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Animations : EnemyAnimations
{
    public override void Idle()
    {
        anim.SetBool(idle, true);
        anim.SetBool(walking, false);
        anim.SetBool(ko, false);
    }

    public override void Walking()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, true);
    }

    public override void AttackPunch()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetTrigger(attack_punch);
        anim.SetBool(ko, false);
    }

    public override void AttackClub()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(ko, false);
    }

    public override void Hit()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetTrigger(hit);
        anim.SetBool(ko, false);
    }



    public override void KO()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(ko, true);
    }
}