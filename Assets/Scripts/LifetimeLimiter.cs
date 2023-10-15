using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeLimiter : MonoBehaviour
{
    public float Seconds = 1.0f;
    void Start()
    {
        Destroy(gameObject, Seconds);    
    }
}
