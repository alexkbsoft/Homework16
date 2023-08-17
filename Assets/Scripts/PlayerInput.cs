using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Shooter _shooter;

    private float _lastDir;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalConstants.HORIZONTAL_AXIS);
        bool jump = Input.GetButtonDown(GlobalConstants.JUMP);

        _playerMovement.Move(horizontalDirection, jump);

        if (!Mathf.Approximately(horizontalDirection, 0)) {
            _lastDir = horizontalDirection;
        }

        if (Input.GetButtonDown(GlobalConstants.FIRE)) {
            _shooter.Shoot(_lastDir);
        }
    }
}
