using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerController _playerController;
    private CameraManager _cameraManager;
    [SerializeField] private PhotonView _view;
    [SerializeField] private PhotonTransformViewClassic _photonTransformViewClassic;
    [Inject]
    private void Construct(PlayerController playerController,
        CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
        _playerController = playerController;
        playerController.OnInputMovement.AddListener(Move);
    }

    private void Move(Vector2 direction)
    {
            Transform transformPlayer;
            (transformPlayer = transform).rotation = Quaternion.Euler(new Vector3(0,_cameraManager.CameraTransform.transform.eulerAngles.y,0));
            Vector3 moveDirection = transformPlayer.forward * direction.y + transformPlayer.right * direction.x;
            transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
