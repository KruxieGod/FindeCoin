using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private IPlayerController _playerController;
    private CameraManager _cameraManager;
    [SerializeField] private PhotonView _view;
    [SerializeField] private PhotonTransformViewClassic _photonTransformViewClassic;

    [Inject]
    private void Construct(IPlayerController playerController,
        CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
        _cameraManager._toPursue = transform;
        _playerController = playerController;
        playerController.OnInputMovement.AddListener(Move);
    }

    private void Move(Vector2 direction)
    {
        if (!_view.IsMine) return;
        Transform transformPlayer;
        (transformPlayer = transform).rotation = Quaternion.Euler(new Vector3(0,_cameraManager.YPivotTransform.transform.eulerAngles.y,0));
        Vector3 moveDirection = transformPlayer.forward * direction.y + transformPlayer.right * direction.x;
        transform.position += moveDirection * _speed * Time.deltaTime;
    }
}
