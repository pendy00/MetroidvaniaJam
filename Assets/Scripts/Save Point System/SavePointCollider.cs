using UnityEngine;

public class SavePointCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Giocatore"))
        {
            FindObjectOfType<SavePointController>().SaveGame();
        }
    }
}