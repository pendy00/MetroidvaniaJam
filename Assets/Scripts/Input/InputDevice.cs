using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputDevice : MonoBehaviour
{
    public abstract void GetUserInput(PlayerInput controller);
}