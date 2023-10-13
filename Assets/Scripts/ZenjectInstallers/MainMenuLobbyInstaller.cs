using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuLobbyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsTransient().WithArguments("GameScene");
        Container.InstantiateComponent<RoomControllerNetwork>(new GameObject());
    }
}
