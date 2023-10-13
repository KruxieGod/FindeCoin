using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class MainMenuLobbyUI : GUI
{
    [field: SerializeField] public TextMeshProUGUI TextWaiting;
    [SerializeField] private InputVariable _createRoom;
    [SerializeField] private InputVariable _loadRoom;
    public UnityEvent<string> OnCreateRoom => _createRoom.OnClick;
    public UnityEvent<string> OnLoadRoom => _loadRoom.OnClick;
    public UnityEvent OnPressedAnyButton { get; private set; } = new();

    private void Start()
    {
        _createRoom.OnClick.AddListener(str => OnPressedAnyButton.Invoke());
        _loadRoom.OnClick.AddListener(str => OnPressedAnyButton.Invoke());
    }
}