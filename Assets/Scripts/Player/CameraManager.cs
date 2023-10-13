using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class CameraManager : MonoBehaviour
{
    public Transform _toPursue;
    [SerializeField] private Transform _pivotCamera;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensMouseSpeed;
    public Transform CameraTransform => _pivotCamera.transform;
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
        var eulerAngles = _pivotCamera.rotation.eulerAngles;
        _pivotCamera.rotation = 
            Quaternion.Euler(
                new Vector3(
                    eulerAngles.x,
                    eulerAngles.y + direction.x * _sensMouseSpeed,
                    eulerAngles.z));
    }
}
