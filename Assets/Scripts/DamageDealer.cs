using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _selfDestruct;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Damagable")) {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);

            if (_selfDestruct) {
                Destroy(gameObject);
            }
        }
    }
}
