using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - target.transform.position;
    }
    void Update()
    {
        this.transform.position = target.transform.position + offset;
    }
}