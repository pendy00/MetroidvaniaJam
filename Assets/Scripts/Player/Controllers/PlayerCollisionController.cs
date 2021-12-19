using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private GameItem item;
    private GameItemInterfaces.Interactable interactable;

    public GameItem Item { get => item; set => item = value; }
    public GameItemInterfaces.Interactable Interactable { get => interactable; set => interactable = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GameItemInterfaces.Interactable>() != null)
        {
            if (collision.gameObject.GetComponent<GameItemInterfaces.Interactable>())
            {
                interactable = collision.gameObject.GetComponent<GameItemInterfaces.Interactable>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        interactable = null;
    }
}