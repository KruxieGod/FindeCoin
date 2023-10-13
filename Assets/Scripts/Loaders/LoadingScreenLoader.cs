
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class LoadingScreenLoader : AssetLoader
{
    private DiContainer _container;
    public LoadingScreenLoader(DiContainer container) => _container = container;
    public async UniTask LoadAndDestroy(ILoadingOperation[] loadingOperations)
    {
        var loadingScreen = await LoadAsync<LoadingScreen>(PathsToAddressable.LOADING_SCREEN_UI);
        _container.Inject(loadingScreen);
        await loadingScreen.Load(loadingOperations);
        Unload();
    }

    private void Unload()
    {
        Debug.Log("UnLoad");
        if (_cachedObject == null)
            return;
        _cachedObject.SetActive(false);
        Addressables.ReleaseInstance(_cachedObject);
        _cachedObject = null;
    }
}