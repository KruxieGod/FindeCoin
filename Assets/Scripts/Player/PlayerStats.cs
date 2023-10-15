using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using ModestTree;
using Photon.Pun;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
public class PlayerStats : MonoBehaviourPunCallbacks, INameable
{
    public List<Func<string>> OnResult { get; private set; } = new();
    public string NamePlayer { get; private set; }
    [SerializeField] private ParticleSystem _particles;
    private Collider _collider;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private int _maxHp;
    private Action<float> _setHpBarSlider;
    private int _currentHp;

    [Inject]
    private void Construct(HpBarUI hpBarUI,
        LoginLoader loginLoader)
    {
        _setHpBarSlider = hpBarUI.SetSliderValue;
        _setHpBarSlider.Invoke(1);
        var namePlayer = loginLoader.NamePlayer;
        SetName(namePlayer);
        _photonView.RPC("SetName",RpcTarget.Others,namePlayer);
    }

    [PunRPC]
    public void SetName(string namePlayer)
    {
        NamePlayer = namePlayer;
        Events.OnPlayerResultMatch.Add(() => namePlayer + " "+ OnResult.Select(x => x.Invoke()).Join(" "));
    }

    private void Awake()
    {
        _currentHp = _maxHp;
        _collider = GetComponent<Collider>();
        DataColliders.OnDamageTake.Add(_collider,TakeDamageServer);
    }

    private void TakeDamageServer(int damage,Vector3 positionHit)
    {
        TakeDamage(damage,positionHit);
        _photonView.RPC("TakeDamage",RpcTarget.Others,damage ,positionHit);
    }

    [PunRPC]
    private void TakeDamage(int damage,Vector3 positionHit)
    {
        _currentHp = Mathf.Clamp(_currentHp - damage,0,_maxHp);
        if (_currentHp == 0)
            Events.OnLose.Invoke(_photonView.IsMine);
        _setHpBarSlider?.Invoke((float)_currentHp/_maxHp);
        Destroy(Instantiate( _particles, positionHit,Quaternion.identity).gameObject,2f);
    }

    public override void OnWebRpcResponse(OperationResponse response)
    {
        
    }
}
