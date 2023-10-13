
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerLoader : ILoadingOperation
{
    [InjectOptional] private DiContainer _container;
    [InjectOptional] private PlayerMovement _player;
    public GameObject Player { get; private set; }
    public string Description => "Player loading...";

    public async UniTask<PlayerMovement> GetPlayer()
    {
        await UniTask.WaitUntil(() => !Player.IsUnityNull());
        return Player.GetComponent<PlayerMovement>();
    }

    public async UniTask Load(Action<float> onProcess)
    {
        Player = _player.gameObject;
        Player = PhotonNetwork.Instantiate(Player.gameObject.name, Vector3.one, Quaternion.identity);
    }
}