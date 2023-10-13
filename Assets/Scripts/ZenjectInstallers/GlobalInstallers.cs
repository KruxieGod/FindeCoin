using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstallers : MonoInstaller
{
    [SerializeField] private Camera _uiCamera;
    public override void InstallBindings()
    {
        var camera = Instantiate(_uiCamera);
        DontDestroyOnLoad( camera);
        Container.Bind<Camera>().FromInstance(camera).AsSingle();
    }
}
