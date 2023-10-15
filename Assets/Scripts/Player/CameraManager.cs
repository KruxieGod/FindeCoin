using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class CameraManager : MonoBehaviour
{
    private float _xAngle = 0;
    [SerializeField]private float _rangeAngle;
    public Transform _toPursue;
    [SerializeField] private Transform _pivotXCamera;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensMouseSpeed;
    public Transform YPivotTransform => transform;
    public Transform XPivotTransform => _pivotXCamera;
    private void Update()
    {
        if (!_toPursue.IsUnityNull())
            transform.position = _toPursue.position;
    }

    [Inject]
    private void Construct(PlayerController playerController)
    {
        playerController.OnMouseInputMovement.AddListener(MoveCamera);
    }

    private void MoveCamera(Vector2 direction)
    {
        var eulerAnglesY = transform.localEulerAngles;
        transform.localRotation = 
            Quaternion.Euler(
                new Vector3(
                    eulerAnglesY.x,
                    eulerAnglesY.y + direction.x * _sensMouseSpeed,
                    eulerAnglesY.z));
        var eulerAnglesX = _pivotXCamera.localEulerAngles;
        _xAngle -= direction.y * _sensMouseSpeed;
        if (_xAngle < -_rangeAngle)
            _xAngle = -_rangeAngle;
        else if (_xAngle >= _rangeAngle)
            _xAngle = _rangeAngle;
        _pivotXCamera.localRotation = 
            Quaternion.Euler(
                new Vector3(
                    _xAngle,
                    eulerAnglesX.y,
                    eulerAnglesX.z));
    }
}
