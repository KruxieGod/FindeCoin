
using Photon.Pun;
using Photon.Realtime;
using Zenject;

public class RoomControllerNetwork : MonoBehaviourPunCallbacks
{
    [Inject] private SceneLoader _sceneLoader;
    
    private void CreateRoom(string nameRoom)
    {
        var room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(nameRoom,room);
    }

    private void JoinRoom(string nameRoom)
    {
        PhotonNetwork.JoinRoom(nameRoom);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(_sceneLoader.NameScene);
    }
}