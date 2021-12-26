using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovements : MonoBehaviour
{
    private Rigidbody2D rb;

    protected Rigidbody2D Rb { get => rb; set => rb = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void LookAtTarget(Transform target);

    public abstract void MoveEnemy(Vector3 direction);
}