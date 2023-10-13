using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Zenject.SpaceFighter;

public class TestSpawnerPlayers :MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform[] _positions;
    [Inject] private PlayerLoader _player;
    [Inject] private CameraManager cameraManager;
    [Inject] private DiContainer _container;
    private async void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber <= _positions.Length)
        {
            var index = PhotonNetwork.LocalPlayer.ActorNumber - 1;
            var player =  await _player.GetPlayer();
            _container.Inject(player);
            player.transform.position = _positions[index].position;
            cameraManager._toPursue =player.transform;
        }
    }

    private void Update()
    {
        Debug.Log(Input.GetKeyDown(KeyCode.Space));
    }
}
