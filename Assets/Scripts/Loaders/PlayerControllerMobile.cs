
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerControllerMobile : IPlayerController,ITickable
{
    public UnityEvent OnLeftMouseClick { get; } = new();
    public UnityEvent<Vector2> OnInputMovement { get; } = new();
    public UnityEvent<Vector2> OnMouseInputMovement { get; } = new();
    private UnityEvent _onTick = new();
    public void DisablePlayerInput()
    => _onTick.RemoveListener(PlayerMovement);

    private readonly MovementMobileUI _movementMobileUI;

    public PlayerControllerMobile(MovementMobileUI movementMobileUI)
    {
        _onTick.AddListener(PlayerMovement);
        _movementMobileUI = movementMobileUI;
        _movementMobileUI.OnFireClick.onClick.AddListener(OnLeftMouseClick.Invoke);
    }

    public void Tick()
    => _onTick.Invoke();
    
    private void PlayerMovement()
    {
        OnInputMovement.Invoke(new Vector2(_movementMobileUI.JoystickMovement.Horizontal,_movementMobileUI.JoystickMovement.Vertical));
        OnMouseInputMovement.Invoke(new Vector2(_movementMobileUI.JoystickView.Horizontal,_movementMobileUI.JoystickView.Vertical));
    }
}