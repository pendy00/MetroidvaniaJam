using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movements : EnemyMovements
{
    public float walking_speed;
    public override void LookAtTarget(Transform target)
    {
        float x = this.transform.position.x > target.position.x ? -1 : 1;

        this.transform.localScale = new Vector3(x, 1, 1);
    }

    public override void MoveEnemy(Vector3 direction)
    {
        Rb.MovePosition(this.transform.position + (direction * walking_speed * Time.fixedDeltaTime));
        this.transform.localScale = new Vector3(1.0f * direction.x, 1, 1);
    }
}