using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsLoader : MonoBehaviour
{
    //Ricerca e caricamento script
    public static T LoadScript<T>() where T : MonoBehaviour
    {
        T temp = null;
        float load_timeout = 2.0f;

        while (temp == null)
        {
            temp = FindObjectOfType<T>();
            load_timeout -= Time.deltaTime;

            if (load_timeout <= 0)
            {
                print("CANT FIND " + temp);
                return null;
            }
        }

        return temp;
    }
}