using UnityEngine;

// define input device used by the player
public abstract class InputDevice : MonoBehaviour
{
    public enum DEVICE_TYPE { KEYBOARD, JOYPAD, TOUCH}; // input device type
    public DEVICE_TYPE device_type;
    private bool is_active;

    public bool Is_active { get => is_active; set => is_active = value; }

    // select and activate input device
    public InputDevice SelectDevice()
    {
        is_active = true;
        return this;
    }

    // unselect and deactivate input device
    public void UnselectDevice()
    {
        is_active = false;
    }

    public abstract void UpdateInput(PlayerInput player_input);
}