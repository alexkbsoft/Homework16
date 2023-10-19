using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health _health;
    void Start()
    {
        _health = GetComponent<Health>();
        _health.Dead += OnDead;
    }

    private void OnDead() {
        EventBus.Invoke(EventConstants.Killed, new CustomEvent());
        
        Destroy(gameObject);
    }

    
    void OnDestroy() {
        _health.Dead -= OnDead;
    }
}
