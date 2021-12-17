using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private EnemyController enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
            enemy = null;
    }
}