using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private float TimeToRevert = 2.0f;
    private Animator _animator;
    private SpriteRenderer _sp;

    private Rigidbody2D _rb;

    private const int IDLE_STATE = 0;
    private const int WALK_STATE = 1;

    private int _currentState = 1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsMoving", true);

    }

    void Update()
    {
        if (_currentState == WALK_STATE) {
            _rb.velocity = new Vector2(Speed, _rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (_currentState == WALK_STATE && coll.CompareTag("EnemyTrigger"))
        {
            _currentState = IDLE_STATE;
            _animator.SetBool("IsMoving", false);
            Invoke("Revert", TimeToRevert);
        }
    }

    void Revert()
    {
        _currentState = WALK_STATE;
        _animator.SetBool("IsMoving", true);
        _sp.flipX = !_sp.flipX;
        Speed *= -1;
    }
}
