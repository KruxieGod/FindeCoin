using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class StartUpInstaller : MonoInstaller
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private ConnectToServer _connectToServer;
    [Inject] private StartUpSceneLoader _startUpSceneLoader;
    public override void InstallBindings()
    {
        DontDestroyOnLoad(_eventSystem);
        Container.Bind<ILoadingOperation>().FromInstance(_connectToServer).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().WithArguments("LobbyScene");
        Container.Inject(_startUpSceneLoader);
    }
}
