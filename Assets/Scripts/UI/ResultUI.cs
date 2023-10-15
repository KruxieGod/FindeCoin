using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Button _quitButton;
    [field: SerializeField] public TextMeshProUGUI TextResult { get; private set; }
    public UnityEvent OnClick => _quitButton.onClick;
}
