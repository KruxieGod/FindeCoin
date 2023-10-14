
using System;
using Photon.Pun;
using UnityEngine;

public class Coin : MonoBehaviourPunCallbacks
{
    [SerializeField] private int _coinAward;
    [SerializeField] private PhotonView _view;
    private void OnTriggerEnter(Collider other)
    {
        if (!DataColliders.CoinCollection.TryGetValue(other, out var action))
            return;
        action?.Invoke(_coinAward);
        Destroy(gameObject);
    }
}