using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _firePoint;


    public void Shoot(float direction) {
        var newBullet = Instantiate(_bullet, 
            _firePoint.position,
            Quaternion.identity);
            
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = new Vector2(
            _fireSpeed * Mathf.Sign(direction),
            bulletRb.velocity.y);
    }
}
