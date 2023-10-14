
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerController : IDisposable,ITickable
{
    public UnityEvent<Vector2> OnInputMovement { get; private set; } = new();
    public UnityEvent<Vector2> OnMouseInputMovement { get; private set; } = new();
    private PlayerControls _playerControls;
    private readonly UnityEvent _onTick = new();

    public PlayerController()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        OnInputMovement.AddListener(vect =>  Debug.Log( "Movement: "+vect));
        OnMouseInputMovement.AddListener(vect => Debug.Log("Mouse: "+vect));
        _onTick.AddListener(PlayerMovement);
    }

    public void DisablePlayerInput()
    => _onTick.RemoveListener(PlayerMovement);
    
    public void Tick()
    => _onTick.Invoke();

    private void PlayerMovement()
    {
        OnInputMovement.Invoke(_playerControls.Movement.Movement.ReadValue<Vector2>());
        OnMouseInputMovement.Invoke(_playerControls.Movement.Mouse.ReadValue<Vector2>());
    }
    
    public void Dispose()
    {
        _playerControls.Enable();
    }
}