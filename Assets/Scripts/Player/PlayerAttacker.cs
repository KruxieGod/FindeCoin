using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
public class PlayerAttacker : MonoBehaviour
{
    private Collider _collider;
    [SerializeField] private int _damage;
    private CameraManager _cameraManager;
    [Inject]
    private void Construct(IPlayerController controller,
        CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
        controller.OnLeftMouseClick.AddListener(DoRayCast);
    }

    private void Awake()
    => _collider = GetComponent<Collider>();

    private void DoRayCast()
    {
        if (!Physics.Raycast(_cameraManager.CameraPosition, _cameraManager.CameraForward, out var hit))
            return;
        if (hit.collider != _collider && DataColliders.OnDamageTake.TryGetValue(hit.collider, out var action))
            action.Invoke(_damage,hit.point);
    }
}
