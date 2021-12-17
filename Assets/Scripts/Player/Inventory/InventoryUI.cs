using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Image inventario;

    private void Awake()
    {
        inventario = GetComponent<Image>();
    }
    public void ShowInventory(bool value)
    {
        if (value)
        {
            inventario.color = Color.white;
        }
        else
        {
            inventario.color = new Color(1, 1, 1, 0);
        }
    }
}