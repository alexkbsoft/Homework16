using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float CurrentDirection => _currentDirection;

    [Header("Movement")]
    [SerializeField] float _jumpForce = 2;
    [SerializeField] float _velocity = 4;
    [SerializeField] bool _isGrounded = false;
    [SerializeField] AnimationCurve _curve;

    [Header("Settings")]
    [SerializeField] float _jumpOffset = 2;
    [SerializeField] Transform _groundCollider;

    [Header("Other")]
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _deathPanel;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Health _health;

    private float _currentDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
        _health.Dead += OnDeath;
    }

    private void OnDeath()
    {
        _animator.SetTrigger("IsDead");
        _deathPanel.SetActive(true);

        Invoke("DestroyDelayed", 1.0f);
    }

    private void DestroyDelayed() {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (!_health._isAlive)
        {
            return;
        }

        var overlapGroundPos = _groundCollider.position;

        var collider = Physics2D.OverlapCircle(overlapGroundPos,
            _jumpOffset,
            1 << LayerMask.NameToLayer(PhysicsLayers.Ground));

        _isGrounded = collider != null;

        _animator.SetFloat("Direction", _rb.velocity.y);
        _animator.SetBool("Grounded", _isGrounded);
    }

    public void Move(float horizontalDirection, bool isJump)
    {
        if (!_health._isAlive)
        {
            return;
        }

        if (isJump)
        {
            Jump();
        }

        bool isMoving = !Mathf.Approximately(horizontalDirection, 0);

        _animator.SetBool("IsRunning", isMoving);

        if (isMoving)
        {
            HorizontalMove(horizontalDirection);
        }

        if (!Mathf.Approximately(horizontalDirection, 0)) {
            _currentDirection = horizontalDirection;
            _spriteRenderer.flipX = horizontalDirection < 0;

            var curPos = _firePoint.transform.localPosition;
            curPos.x = Mathf.Sign(horizontalDirection) * Mathf.Abs(curPos.x);
            _firePoint.transform.localPosition = curPos;
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void HorizontalMove(float dir)
    {
        _rb.velocity = new Vector2(_curve.Evaluate(dir), _rb.velocity.y);
    }

    void OnDestroy() {
        _health.Dead -= OnDeath;
    }
}
