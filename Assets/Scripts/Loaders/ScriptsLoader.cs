using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    //Find and load the script
    public static T LoadScript<T>() where T : MonoBehaviour
    {
        T temp = null;
        float load_timeout = 2.0f; // set a timeout to avoid infinite loop possibility

        while (temp == null)
        {
            temp = FindObjectOfType<T>();
            load_timeout -= Time.deltaTime;

            // script reference not found in the scene
            if (load_timeout <= 0)
            {
                print("CANT FIND " + temp);
                return null;
            }
        }

        return temp;
    }
}