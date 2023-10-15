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

        EventBus.AddListener(EventConstants.CUTSCENE_START, BlockPlayer);
        EventBus.AddListener(EventConstants.CUTSCENE_END, UnblockPlayer);
    }

    void Update()
    {
        if (_isBlocked) {
            return;
        }

        float horizontalDirection = Input.GetAxis(GlobalConstants.HORIZONTAL_AXIS);
        bool jump = Input.GetButtonDown(GlobalConstants.JUMP);

        _playerMovement.Move(horizontalDirection, jump);

        if (Input.GetButtonDown(GlobalConstants.FIRE))
        {
            _shooter.Shoot();
        }
    }

    void OnDestroy()
    {
        EventBus.AddListener(EventConstants.CUTSCENE_START, BlockPlayer);
        EventBus.AddListener(EventConstants.CUTSCENE_END, UnblockPlayer);
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
