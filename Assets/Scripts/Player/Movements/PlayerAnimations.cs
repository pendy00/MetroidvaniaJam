using UnityEngine;

//gestisce le animazioni del personaggio tramite Animator
public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    private const string idle = "idle";
    private const string walking = "walking";
    private const string jumping = "jumping";
    private const string crouching = "crouching";
    private const string phone = "phone";
    private const string base_attack = "base attack";
    private const string grab_object = "grab object ground";
    private const string hit_light = "hit light";
    private const string running = "running";

    private const string walking_speed = "walking speed";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //attiva l'animazione idle
    public void Idle()
    {
        anim.SetBool(idle, true);
        anim.SetBool(walking, false);
        anim.SetBool(jumping, false);
        anim.SetBool(crouching, false);
        anim.SetBool(base_attack, false);
        anim.SetBool(hit_light, false);
        anim.SetBool(grab_object, false);
        anim.SetBool(running, false);
    }

    //attiva l'animazione di camminata
    public void Walking()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, true);
        anim.SetBool(running, false);
    }

    //attiva l'animazione di salto
    public void Jumping()
    {
        anim.SetBool(idle, false);
        anim.SetBool(jumping, true);
        anim.SetBool(walking, false);
        anim.SetBool(jumping, false);
    }

    //attiva l'animazione di accovacciamento
    public void Crouching()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(crouching, true);
    }

    //attiva l'animazione attacco base
    public void BaseAttack()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(crouching, false);
        anim.SetBool(base_attack, true);
        anim.SetBool(running, false);
    }

    //attiva l'animazione hit leggero
    public void LightHit()
    {
        anim.SetBool(hit_light, true);
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(crouching, false);
        anim.SetBool(base_attack, false);
        anim.SetBool(running, false);
    }

    public void Running()
    {
        anim.SetBool(idle, false);
        anim.SetBool(walking, false);
        anim.SetBool(running, true);
    }
}