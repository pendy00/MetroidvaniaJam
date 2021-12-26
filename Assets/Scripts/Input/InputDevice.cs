using UnityEngine;

public abstract class InputDevice : MonoBehaviour
{
    public enum DEVICE_TYPE { KEYBOARD, JOYPAD, TOUCH};
    public DEVICE_TYPE device_type;
    private bool is_active;

    public bool Is_active { get => is_active; set => is_active = value; }

    public InputDevice SelectDevice()
    {
        is_active = true;
        return this;
    }

    public void UnselectDevice()
    {
        is_active = false;
    }

    public abstract void UpdateInput(PlayerInput player_input);
}