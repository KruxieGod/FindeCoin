using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class StartUpInstaller : MonoInstaller
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private ConnectToServer _connectToServer;
    public override void InstallBindings()
    {
        DontDestroyOnLoad(_eventSystem);
        Container.Bind<ILoadingOperation>().FromInstance(_connectToServer).AsSingle();
        Container.Bind<LoadingScreenLoader>().AsTransient();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsTransient().WithArguments("LobbyScene");
    }
}
