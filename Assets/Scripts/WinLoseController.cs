
using System;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class WinLoseController
{
    private WinLoseUI _winLoseUI;
    private readonly PlayerController _playerController;
    private readonly StartUpSceneLoader _startUpSceneLoader;
    public WinLoseController(WinLoseUI winLoseUI,
        PlayerController playerController,
        StartUpSceneLoader startUpSceneLoader)
    {
        _startUpSceneLoader = startUpSceneLoader;
        _winLoseUI = winLoseUI;
        _playerController = playerController;
        Events.OnLose.AddListener(WinOfMine);
    }

    private void WinOfMine(bool isMine,string name)
    {
        isMine = !isMine;
        _playerController.DisablePlayerInput();
        Action action = () =>
        {
            PhotonNetwork.LeaveRoom();
            _startUpSceneLoader.Load();
        };
        _winLoseUI.WinUI.OnClick.AddListener( action.Invoke);
        _winLoseUI.LoseUI.OnClick.AddListener( action.Invoke);
        if (isMine)
            _winLoseUI.WinUI.gameObject.SetActive(true);
        else
            _winLoseUI.LoseUI.gameObject.SetActive(true);
    }
}