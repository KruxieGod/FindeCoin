
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public interface ILoadingOperation
{
    string Description { get; }
    UniTask Load(Action<float> onProcess);
}