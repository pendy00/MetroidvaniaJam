using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Load/unload game scenes and grant them access for interaction
public class SceneController : MonoBehaviour
{
    public static void TimeScale(float time)
    {
        Time.timeScale = time;
    }
}