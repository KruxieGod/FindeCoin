using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
//Можно сделать и обычным c# скриптом через Zenject без монобеха
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private PhotonView _view;
    private int _countCoins = 0;
    private Action<int> _setTextCoin;
    private Collider _collider;
    private WinLoseController _winLoseController;
    private const int _winCountCoins = 5; // можно сделать и считывание с файла , сколько будет монеток и сюда же передавать сколько нужно для победы:
    [Inject]
    private void Construct(CoinCollectorUI coinCollectorUI)
    => _setTextCoin = coinCollectorUI.SetCoins;
    
    private void Awake()
    {
        GetComponent<PlayerStats>().OnResult.Add(() => "collected "+_countCoins + " coins");
        _collider = GetComponent<Collider>();
        DataColliders.CoinCollection.Add(_collider,AddCoin);
    }

    private void AddCoin(int count)
    {
        if (!_view.IsMine) 
            return;
        AddCoinServer(count);
        _view.RPC("AddCoinServer",RpcTarget.Others,count);
    }

    [PunRPC]
    private void AddCoinServer(int count)
    {
        _countCoins += count;
        _setTextCoin?.Invoke(_countCoins);
    }

    private void OnDestroy()
    => DataColliders.CoinCollection.Remove(_collider);
}
