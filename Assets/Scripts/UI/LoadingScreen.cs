using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadingScreen : GUI
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _speedBar;
    private float _targetProgress;
    
    public async Task Load(ILoadingOperation[] queue)
    {
        DontDestroyOnLoad(this);
        _canvas.enabled = true;
        StartCoroutine(UpdateSlider());
        
        foreach (var operation in queue)
        {
            ResetFill();
            _text.text = operation.Description;
            await operation.Load(OnProgress);
            await Wait();
        }

        _canvas.enabled = false;
    }

    private async Task Wait()
    {
        while (_slider.value < _targetProgress)
        {
            await Task.Yield();
        }
    }

    private void OnProgress(float value)
    {
        _targetProgress = value;
    }

    private void ResetFill()
    {
        Debug.Log("ResetFill");
        _slider.value = 0;
        _targetProgress = 0;
    }

    private IEnumerator UpdateSlider()
    {
        Debug.Log("Slider is updating");
        while (_canvas.enabled)
        {
            Debug.Log(_targetProgress);
            if (_slider.value < _targetProgress)
                _slider.value += Time.deltaTime * _speedBar;
            yield return null;
        }
    }
}
