using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movements : EnemyMovements
{
    public override void LookAtTarget(Transform target)
    {
        float x = this.transform.position.x > target.position.x ? -1 : 1;

        this.transform.localScale = new Vector3(x, 1, 1);
    }
}