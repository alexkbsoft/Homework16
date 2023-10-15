using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _firePoint;

    private PlayerMovement _playerMovement;
    private Animator _animator;

    void Start() {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    public void Shoot() {
        _animator.SetTrigger("IsAttacking");

        var newBullet = Instantiate(_bullet,
            _firePoint.position,
            Quaternion.identity);
            
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = new Vector2(
            _fireSpeed * Mathf.Sign(_playerMovement.CurrentDirection),
            bulletRb.velocity.y);
    }
}
