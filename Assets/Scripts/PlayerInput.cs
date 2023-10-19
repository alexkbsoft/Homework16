using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Shooter _shooter;
    private bool _isBlocked = false;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooter = GetComponent<Shooter>();

        EventBus.AddListener(EventConstants.CutsceneStart, BlockPlayer);
        EventBus.AddListener(EventConstants.CutsceneEnd, UnblockPlayer);
    }

    void Update()
    {
        if (_isBlocked) {
            return;
        }

        float horizontalDirection = Input.GetAxis(GlobalConstants.HorizontalAxis);
        bool jump = Input.GetButtonDown(GlobalConstants.Jump);

        _playerMovement.Move(horizontalDirection, jump);

        if (Input.GetButtonDown(GlobalConstants.Fire))
        {
            _shooter.Shoot();
        }
    }

    void OnDestroy()
    {
        EventBus.AddListener(EventConstants.CutsceneStart, BlockPlayer);
        EventBus.AddListener(EventConstants.CutsceneEnd, UnblockPlayer);
    }

    private void BlockPlayer(CustomEvent ev)
    {
        _isBlocked = true;
    }

    private void UnblockPlayer(CustomEvent ev)
    {
        _isBlocked = false;
    }
}
