using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private PlayerController player_controller;
    private PlayerUIController player_ui_controller;

    private void Start()
    {
        player_controller = FindObjectOfType<PlayerController>();
        player_ui_controller = FindObjectOfType<PlayerUIController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnMouseDown()
    {
        player_ui_controller.UpdateLifeBarUI(-10.0f);
        player_ui_controller.UpdateExpBar(+10.0f);
    }
}