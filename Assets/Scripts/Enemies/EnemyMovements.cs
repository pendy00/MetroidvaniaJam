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
    public void Update()
    {
        if (rb.velocity.x != 0)
            rb.gravityScale = 2.5f;
        else
            rb.gravityScale = 1.0f;
    }

    public abstract void LookAtTarget(Transform target);
}