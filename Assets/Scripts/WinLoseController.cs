
using System;
using System.Linq;
using ModestTree;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class WinLoseController
{
    private WinLoseUI _winLoseUI;
    private readonly IPlayerController _playerController;
    private readonly StartUpSceneLoader _startUpSceneLoader;
    public WinLoseController(WinLoseUI winLoseUI,
        IPlayerController playerController,
        StartUpSceneLoader startUpSceneLoader)
    {
        _startUpSceneLoader = startUpSceneLoader;
        _winLoseUI = winLoseUI;
        _playerController = playerController;
        Events.OnLose.AddListener(WinOfMine);
    }

    private void WinOfMine(bool isMine)
    {
        isMine = !isMine;
        _playerController.DisablePlayerInput();
        Action action = () =>
        {
            PhotonNetwork.LeaveRoom();
            _startUpSceneLoader.Load();
        };
        string name = Events.OnPlayerResultMatch.Select(func => func.Invoke()).Join(" ");
        if (isMine)
        {
            _winLoseUI.WinUI.TextResult.SetText(name);
            _winLoseUI.WinUI.OnClick.AddListener( action.Invoke);
            _winLoseUI.WinUI.gameObject.SetActive(true);
        }
        else
        {
            _winLoseUI.LoseUI.TextResult.SetText(name);
            _winLoseUI.LoseUI.OnClick.AddListener( action.Invoke);
            _winLoseUI.LoseUI.gameObject.SetActive(true);
        }
    }
}