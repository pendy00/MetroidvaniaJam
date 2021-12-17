using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : EnemyAI
{
    private PlayerController target;
    public float attack_distance;
    public float hit_delay;
    private float HIT_DELAY;

    private void Start()
    {
        HIT_DELAY = hit_delay;
        hit_delay = 0;
    }
    public void Update()
    {
        if(target != null)
        {
            if (hit_delay > 0)
                hit_delay -= Time.fixedDeltaTime;

            Enemy_controller.Enemy_movements.LookAtTarget(target.gameObject.transform);

            float distance = Vector3.Distance(target.gameObject.transform.position, this.gameObject.transform.position);

            if(Mathf.Abs(distance) <= attack_distance && hit_delay <= 0.0f)
            {
                Enemy_controller.Enemy_animations.AttackPunch();
                target.LightHit(Enemy_controller.Enemy.Forza);
                hit_delay = HIT_DELAY;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            target = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            target = null;
    }
}