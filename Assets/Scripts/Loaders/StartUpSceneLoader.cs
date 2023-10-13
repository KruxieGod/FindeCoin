
using Cysharp.Threading.Tasks;
using Zenject;

public class StartUpSceneLoader
{
    private ILoadingOperation[] _operations;
    private LoadingScreenLoader _loadingScreenLoader;

    [Inject]
    private void Construct(ILoadingOperation[] operations, LoadingScreenLoader loadingScreenLoader)
    {
        _loadingScreenLoader = loadingScreenLoader;
        _operations = operations;
    }

    public UniTask Load()
        => _loadingScreenLoader.LoadAndDestroy(_operations);
}