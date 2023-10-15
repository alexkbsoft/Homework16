using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            EventBus.Invoke(EventConstants.FINISH_REACHED, new CustomEvent());
        }
    }
}
