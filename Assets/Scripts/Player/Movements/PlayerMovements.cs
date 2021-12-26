using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool is_grounded;

    public bool Is_grounded { get => is_grounded; set => is_grounded = value; }
    public Vector2 Falling_speed { get => rb.velocity; set => rb.velocity = value; }


    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y >= 0.0f && rb.velocity.y <= 0.01f)
            is_grounded = true;
        else if(rb.velocity.y < 0.0f || rb.velocity.y > 0.01f)
            is_grounded = false;
    }

    public void LookAtDirection(float direction)
    {
        this.transform.parent.transform.localScale = new Vector3(direction, 1, 1);
    }
    public void MovePlayer(Vector3 direction, float speed)
    {
        this.transform.parent.transform.Translate(direction * speed * Time.fixedDeltaTime);

        LookAtDirection(direction.x);
    }

    public void MovePlayerAirborne(Vector3 direction, float airborne_speed)
    {
        
        this.transform.parent.transform.Translate(direction * airborne_speed * Time.fixedDeltaTime);

        LookAtDirection(direction.x);
    }

    public void Jump(float strenght)
    {
        rb.velocity += (Vector2.up * strenght);
        is_grounded = false;
    }
}