using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuLobby : GUI
{
    [SerializeField] private InputVariable _createLobby;
    [SerializeField] private InputVariable _loadLobby;
    public UnityEvent<string> OnCreateLobby => _createLobby.OnClick;
    public UnityEvent<string> OnLoadLobby => _loadLobby.OnClick;
}