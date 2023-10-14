
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerLoader
{
    [InjectOptional] private PlayerMovement _player;
    public GameObject Player { get; private set; }

    public async UniTask<PlayerMovement> GetPlayer()
    {
        Player = PhotonNetwork.Instantiate(_player.gameObject.name, Vector3.one, Quaternion.identity);
        await UniTask.WaitUntil(() => !Player.IsUnityNull());
        return Player.GetComponent<PlayerMovement>();
    }
}