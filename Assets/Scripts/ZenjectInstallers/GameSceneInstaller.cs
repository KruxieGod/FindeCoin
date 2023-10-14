using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private WinLoseUI _winLoseUI;
    [SerializeField] private CoinCollectorUI _coinCollectorUI;
    [SerializeField] private CameraManager cameraManager;
    [Inject] private StartUpSceneLoader _startUpSceneLoader;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().WithArguments(Scenes.LOBBY_SCENE);
        Container.Bind<WinLoseUI>().FromInstance(_winLoseUI);
        Container.Bind<CoinCollectorUI>().FromInstance(_coinCollectorUI);
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
        Container.Bind<CameraManager>().FromInstance(cameraManager);
        Container.Bind<WinLoseController>().AsSingle();
        Container.Inject(_startUpSceneLoader);
        Container.Inject(Container.Resolve<WinLoseController>());
    }
}
