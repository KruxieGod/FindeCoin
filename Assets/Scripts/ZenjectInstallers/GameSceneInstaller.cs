using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private MovementMobileUI _movementMobileUI;
    [SerializeField] private HpBarUI _hpBarUI;
    [SerializeField] private WinLoseUI _winLoseUI;
    [SerializeField] private CoinCollectorUI _coinCollectorUI;
    [SerializeField] private CameraManager cameraManager;
    [Inject] private StartUpSceneLoader _startUpSceneLoader;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().WithArguments(Scenes.LOBBY_SCENE);
        BindUI();
        Container.BindInterfacesAndSelfTo<PlayerControllerMobile>().AsSingle(); // Mobile
        //Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle(); Desktop
        Container.Bind<CameraManager>().FromInstance(cameraManager);
        Container.Bind<WinLoseController>().AsSingle();
        Container.Inject(_startUpSceneLoader);
        Container.Inject(Container.Resolve<WinLoseController>());
    }

    private void BindUI()
    {
        Container.Bind<MovementMobileUI>().FromInstance(_movementMobileUI);
        Container.Bind<HpBarUI>().FromInstance(_hpBarUI);
        Container.Bind<WinLoseUI>().FromInstance(_winLoseUI);
        Container.Bind<CoinCollectorUI>().FromInstance(_coinCollectorUI);
    }
}
