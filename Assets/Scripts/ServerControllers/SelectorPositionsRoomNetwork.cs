
using Photon.Pun;
using UnityEngine;

public class SelectorPositionsRoomNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform[] _positionsSpawn;

    public override void OnJoinedRoom()
    {
        
    }
}