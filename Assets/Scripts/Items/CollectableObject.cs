using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    private Collectable collectable_values;
    private Sprite sprite;

    public Collectable Collectable_values { get => collectable_values; set => collectable_values = value; }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}