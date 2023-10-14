using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviourPunCallbacks
{
    private const float _offset = 10f;
    [SerializeField] private GameObject _plane;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _countCoins;
    private async void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("MaserClient : "+PhotonNetwork.IsMasterClient);
            await InitializeRoom();
        }
    }

    private async UniTask InitializeRoom()
    {
        Func<Vector2> getRandomPosition = () => Random.insideUnitCircle * _offset*_plane.transform.localScale.x/2f;
        var tasks = new UniTask[_countCoins];
        for (int i = 0; i < tasks.Length; i++)
        {
            var randomPos = getRandomPosition();
            var gameObj = PhotonNetwork.Instantiate(_coinPrefab.gameObject.name, new Vector3(randomPos.x,0,randomPos.y), Quaternion.identity);
            tasks[i] = UniTask.WaitUntil(() => !gameObj.IsUnityNull());
        }
        await UniTask.WhenAll(tasks);
    }
}
