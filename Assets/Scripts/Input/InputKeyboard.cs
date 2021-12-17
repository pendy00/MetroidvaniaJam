using UnityEngine;

// Acquisizione input tramite tastira
public class InputKeyboard : MonoBehaviour
{
    private InputController controller;

    private void Start()
    {
        controller = GetComponent<InputController>(); // "inizializzazione" controller input
    }

    public void Update()
    {
        controller.ResetAllInputs(); //azzera gli input del frame precedente

        if (Input.GetKey(KeyCode.UpArrow))
            controller.Up = true;

        if (Input.GetKey(KeyCode.DownArrow))
            controller.Crouch = true;

        if (Input.GetKey(KeyCode.RightArrow))
            controller.Right = true;

        if (Input.GetKey(KeyCode.LeftArrow))
            controller.Left = true;

        if (Input.GetKey(KeyCode.Space))
            controller.Action = true;

        if (Input.GetKey(KeyCode.LeftControl))
            controller.Attack = true;

        if (Input.GetKeyDown(KeyCode.C))
            controller.Menu = true;

        if (Input.GetKeyDown(KeyCode.X))
            controller.Cancel = true;
    }
}