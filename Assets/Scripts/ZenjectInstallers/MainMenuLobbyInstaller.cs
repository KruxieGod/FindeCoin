using System.Collections;
using System.Collections.Generic;
using Loaders;
using UnityEngine;
using Zenject;

public class MainMenuLobbyInstaller : MonoInstaller
{
    [Inject] private StartUpSceneLoader _startUpSceneLoader;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoaderNetwork>().AsTransient().WithArguments("GameScene");
        Container.InstantiateComponent<RoomControllerNetwork>(new GameObject());
        Container.Inject(_startUpSceneLoader);
    }
}
