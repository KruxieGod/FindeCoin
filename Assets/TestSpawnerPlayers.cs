using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestSpawnerPlayers :MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private Transform _player;
    [SerializeField] private PursueTransform _pursueTransform;
    private void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber <= _positions.Length)
        {
            var index = PhotonNetwork.LocalPlayer.ActorNumber - 1;
            var player = PhotonNetwork.Instantiate(_player.name, _positions[index].position, Quaternion.identity);
            _pursueTransform._toPursue = player.transform;
        }
    }
}
