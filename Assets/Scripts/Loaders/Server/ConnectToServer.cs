using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks, ILoadingOperation
{
    private bool _isConnected;
    public string Description => "Connecting to server...";
    public async UniTask Load(Action<float> onProcess)
    {
        PhotonNetwork.ConnectUsingSettings();
        onProcess?.Invoke(0.3f);
        await UniTask.WaitUntil(() => _isConnected);
        onProcess?.Invoke(1f);
    }

    public override void OnConnectedToMaster()
        => _isConnected = true;
}
