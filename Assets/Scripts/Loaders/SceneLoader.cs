using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ILoadingOperation
{
    public readonly string NameScene;
    public SceneLoader(string nameScene) => NameScene = nameScene;
    public string Description => NameScene+" loading...";
    public async UniTask Load(Action<float> onProcess)
    {
        onProcess?.Invoke(0f);
        await SceneManager.LoadSceneAsync(NameScene);
        onProcess?.Invoke(1f);
    }
}
