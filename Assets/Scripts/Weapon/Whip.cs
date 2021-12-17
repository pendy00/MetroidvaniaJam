using UnityEngine;

public class Whip : MonoBehaviour
{
    private Animator anim;
    private bool hit;
    private EnemyController target;
    private SpriteRenderer sprite_renderer;
    private BoxCollider2D box_collider;

    private const string attack = "attack";

    public Animator Anim { get => anim; set => anim = value; }
    public bool Hit { get => hit; set => hit = value; }
    public EnemyController Target { get => target; set => target = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        box_collider = GetComponent<BoxCollider2D>();

        sprite_renderer.enabled = false;
        box_collider.enabled = false;
    }

    public void Attack()
    {
        sprite_renderer.enabled = true;
        anim.SetBool(attack, true);
    }

    public void ResetAttack()
    {
        sprite_renderer.enabled = false;
        anim.SetBool(attack, false);
        box_collider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            hit = true;
            target = collision.gameObject.GetComponent<EnemyController>();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            hit = false;
            target = null;
        }
    }

    public void EnemyHit()
    {
        hit = false;
        target = null;
    }
}