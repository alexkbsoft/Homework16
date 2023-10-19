using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string Name;

    private bool _isCollected = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if (_isCollected) {
            return;
        }

        _isCollected = true;

        Destroy(gameObject);

        var ev = new CustomEvent(Name);
        EventBus.Invoke(EventConstants.Collected, ev);
    }
}
