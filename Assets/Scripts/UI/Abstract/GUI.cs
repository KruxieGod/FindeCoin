using UnityEngine;
using Zenject;

[RequireComponent(typeof(Canvas))]
public class GUI : MonoBehaviour
{
    [SerializeField] protected Canvas _canvas;
    
    [Inject]
    private void Construct(Camera uiCamera) => _canvas.worldCamera = uiCamera;
}