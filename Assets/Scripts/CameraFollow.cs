using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// follow target movements
public class CameraFollow : MonoBehaviour
{
    public GameObject target; // target to follow
    private Vector3 offset; // offset of the camera compared to the target

    private void Start()
    {
        // calculate offset as set in the scene
        offset = this.transform.position - target.transform.position;
    }
    void Update()
    {
        // update camera position
        this.transform.position = target.transform.position + offset;
    }
}