using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuLobbyPrefabsInstaller : MonoInstaller
{
    [InjectOptional] private PlayerLoader _playerLoader;
    [Inject] private GlobalInstallers _globalInstallers;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private MainMenuLobbyUI _mainMenuLobbyUI;
    [Inject] private LoginLoader _loginLoader;
    public override void InstallBindings()
    {
        SetAnyThings();
        Container.Bind<PlayerMovement>().FromInstance(_player).AsSingle();
        Container.Bind<MainMenuLobbyUI>().FromInstance(_mainMenuLobbyUI).AsSingle();
        if (_playerLoader is null)
            _globalInstallers.GlobalDi.Bind<PlayerLoader>().AsSingle();
        Container.Inject(_globalInstallers.GlobalDi.Resolve<PlayerLoader>());
    }

    private void SetAnyThings()
    {
        _mainMenuLobbyUI.OnSetName.AddListener(_loginLoader.SetName);
    }
}
