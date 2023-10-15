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
    private void Construct(PlayerController controller,
        CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
        controller.OnLeftMouseClick.AddListener(DoRayCast);
    }

    private void Awake()
    => _collider = GetComponent<Collider>();

    private void DoRayCast()
    {
        var yaw = _cameraManager.YPivotTransform.eulerAngles.y;
        var pitch = _cameraManager.XPivotTransform.eulerAngles.x;
        var rotation = Quaternion.Euler(pitch, yaw, 0.0f);
        var cameraDirection = rotation * Vector3.forward;

        if (!Physics.Raycast(transform.position, cameraDirection, out var hit))
            return;
        if (hit.collider != _collider && DataColliders.OnDamageTake.TryGetValue(hit.collider, out var action))
            action.Invoke(_damage,hit.point);
    }
}
