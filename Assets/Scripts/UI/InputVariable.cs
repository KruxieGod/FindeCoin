using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputVariable : MonoBehaviour
{
    [SerializeField] private Button _button;
    [HideInInspector]public UnityEvent<string> OnClick = new();
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        if (!_button.IsUnityNull())
            _button.onClick.AddListener(() => OnClick.Invoke(_text.text));
    }
}
