using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [InjectOptional] private PlayerLoader _player;
    [Inject] private CameraManager cameraManager;
    [Inject] private DiContainer _container;
    private async void Awake()
    {
        if (PhotonNetwork.PlayerList.Length > _positions.Length)
            return;
        if (_player is null)
            return;
        var index = PhotonNetwork.CurrentRoom.Players.TakeWhile(pair => pair.Value != PhotonNetwork.LocalPlayer).Count();
        var player = await _player.GetPlayer();
        foreach (var component in player.gameObject.GetComponents<Component>())
            _container.Inject(component);
        player.transform.position = _positions[index].position;
    }

    private void Update()
    {
        Debug.Log(Input.GetKeyDown(KeyCode.Space));
    }
}
