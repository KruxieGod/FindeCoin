using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AppStartUp : MonoBehaviour
{
    [Inject] private StartUpSceneLoader _loader;
    
    private async void Start()
    => await _loader.Load();
}
