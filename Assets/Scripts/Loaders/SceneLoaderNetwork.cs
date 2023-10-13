using System;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Loaders
{
    public class SceneLoaderNetwork : ILoadingOperation
    {
        private bool _isLoadedScene;
        private string _nameScene;
        public SceneLoaderNetwork(string nameScene) => _nameScene = nameScene;
        public string Description => _nameScene+" loading...";
        public async UniTask Load(Action<float> onProcess)
        {
            onProcess?.Invoke(0f);
            PhotonNetwork.LoadLevel(_nameScene);
            SceneManager.sceneLoaded += (scene, mode) => _isLoadedScene = true;
            await UniTask.WaitUntil(() => _isLoadedScene);
            onProcess?.Invoke(1f);
        }
    }
}