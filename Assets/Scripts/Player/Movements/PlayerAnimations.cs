using UnityEngine;

//gestisce le animazioni del personaggio tramite Animator
public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //attiva l'animazione idle
    public void Idle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
        anim.SetBool("jumping", false);
        anim.SetBool("crouching", false);
    }

    //attiva l'animazione di camminata
    public void Walking()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walking", true);
    }

    //attiva l'animazione di salto
    public void Jumping()
    {
        anim.SetBool("idle", false);
        anim.SetBool("jumping", true);
    }

    //attiva l'animazione di accovacciamento
    public void Crouching()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walking", false);
        anim.SetBool("crouching", true);
    }
}