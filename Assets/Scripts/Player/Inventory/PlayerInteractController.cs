using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    private Interactable interactable;

    private PlayerInputController player_input_controller;

    public Interactable Interactable { get => interactable; set => interactable = value; }

    public void Init(PlayerInputController player_input_controller)
    {
        this.player_input_controller = player_input_controller;
    }
    private void Update()
    {
        if (player_input_controller.Player_input.Action)
        {
            if (interactable != null)
            {
                interactable.Action();
                interactable = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("interactable"))
            interactable = collision.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
}