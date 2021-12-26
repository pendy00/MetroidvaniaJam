using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void SetBool(string parameter, bool value)
    {
        anim.SetBool(parameter, value);
    }

    public void SetFloat(string parameter, float value)
    {
        anim.SetFloat(parameter, value);
    }
}