using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLimitter : MonoBehaviour
{
    public event Action<GameObject> PlatformCollided;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlatformCollided?.Invoke(other.gameObject);
    }
}
