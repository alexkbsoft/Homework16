using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public bool IsAlive => _isAlive;
    [SerializeField] private float _maxHealth;
    public bool _isAlive;
    public event Action Dead;

    private float _currentHealth;
    private UIConnector _uiConnector;

    void Awake() {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    void Start() {
        _uiConnector = GetComponent<UIConnector>();
    }

    public void TakeDamage(float dmg) {
        if (!_isAlive) {
            return;
        }

        _currentHealth -= dmg;

        if (_uiConnector != null) {
            _uiConnector.SetLife(_currentHealth);
        }

        CheckIsAlive();
    }

    private void CheckIsAlive() {
        _isAlive = _currentHealth > 0;

        if (!_isAlive) {
            Dead?.Invoke();
        }
    }
}
