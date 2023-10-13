using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstallers : MonoInstaller
{
    public DiContainer GlobalDi => Container;
    [SerializeField] private Camera _uiCamera;
    public override void InstallBindings()
    {
        var camera = Instantiate(_uiCamera);
        DontDestroyOnLoad( camera);
        Container.Bind<GlobalInstallers>().FromInstance(this).AsSingle();
        Container.Bind<Camera>().FromInstance(camera).AsSingle();
        Container.Bind<LoadingScreenLoader>().AsTransient();
        Container.Bind<StartUpSceneLoader>().AsSingle();
    }
}
