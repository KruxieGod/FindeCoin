
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

public class RoomControllerNetwork : MonoBehaviourPunCallbacks
{
    private SceneLoader _sceneLoader;
    private MainMenuLobbyUI _mainMenuLobbyUI;
    private bool _isCanBeInterrupted;
    private bool _isLeftRoom = true;
    private UniTask _taskLeftRoom = UniTask.CompletedTask;
    private UniTask _taskJoinRoom = UniTask.CompletedTask;
    [Inject]
    private void Construct(MainMenuLobbyUI mainMenuLobbyUI,
        SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _mainMenuLobbyUI = mainMenuLobbyUI;
        mainMenuLobbyUI.OnPressedAnyButton.AddListener(() => _isCanBeInterrupted = true);
        mainMenuLobbyUI.OnCreateRoom.AddListener(CreateRoom);
        mainMenuLobbyUI.OnLoadRoom.AddListener(JoinRoom);
    }
    
    private void CreateRoom(string nameRoom)
    {
        var room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(nameRoom,room);
    }

    private async void JoinRoom(string nameRoom)
    {
        if (PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();
        if (!_isLeftRoom)
            await (_taskLeftRoom = UniTask.WaitUntil(() => _isLeftRoom));
        PhotonNetwork.JoinRoom(nameRoom);
    }

    public override void OnLeftRoom()
    {
        _isLeftRoom = true;
    }

    public override async void OnJoinedRoom()
    {
        if (_taskJoinRoom.Status != UniTaskStatus.Succeeded ||
            _taskLeftRoom.Status != UniTaskStatus.Succeeded)
            return;
        _isCanBeInterrupted = false;
        _mainMenuLobbyUI.TextWaiting.enabled = true;
        _mainMenuLobbyUI.TextWaiting.SetText("Waiting until someone joined" );
        await (_taskJoinRoom = UniTask.WaitUntil(() => PhotonNetwork.CurrentRoom.PlayerCount > 1 || _isCanBeInterrupted));
        _mainMenuLobbyUI.TextWaiting.enabled = false;
        if (_isCanBeInterrupted)
        {
            if (_taskLeftRoom.Status != UniTaskStatus.Pending)
            {
                PhotonNetwork.LeaveRoom();
                await (_taskLeftRoom = UniTask.WaitUntil(() => _isLeftRoom));
            }
            _isCanBeInterrupted = false;
            return;
        }
        
        PhotonNetwork.LoadLevel(_sceneLoader.NameScene);
    }
}