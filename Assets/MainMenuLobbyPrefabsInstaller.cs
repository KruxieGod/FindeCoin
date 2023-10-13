using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuLobbyPrefabsInstaller : MonoInstaller
{
    [SerializeField] private MainMenuLobbyUI _mainMenuLobbyUI;
    public override void InstallBindings()
    {
        Container.Bind<MainMenuLobbyUI>().FromInstance(_mainMenuLobbyUI).AsSingle();
    }
}
