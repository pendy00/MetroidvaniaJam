using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : EnemyAI
{
    private PlayerCombactController target;
    public float patrol_distance;
    private float patrol_start_position;
    public bool can_patrol;
    private float direction;
    public float attack_distance;
    public float hit_delay;
    private float HIT_DELAY;

    private void Start()
    {
        HIT_DELAY = hit_delay;
        hit_delay = 0;

        if (patrol_distance > 0)
            patrol_start_position = this.transform.position.x;

        direction = this.transform.lossyScale.x;
    }

    public void FixedUpdate()
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
                //target.LightHit(Enemy_controller.Enemy.Forza);
                hit_delay = HIT_DELAY;
            }
        }

        if (can_patrol)
            Patrol();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            target = collision.gameObject.GetComponent<PlayerCombactController>();
            Enemy_controller.Enemy_animations.Idle();
            can_patrol = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            can_patrol = true;
            target = null;
        }
    }

    private void Patrol()
    {
        if (this.transform.position.x < patrol_start_position - patrol_distance || this.transform.position.x > patrol_start_position + patrol_distance)
            direction *= -1;

        Enemy_controller.Enemy_movements.MoveEnemy(Vector3.right * direction);
        Enemy_controller.Enemy_animations.Walking();
    }
}