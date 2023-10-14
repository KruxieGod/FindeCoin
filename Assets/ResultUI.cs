using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Button _quitButton;
    public UnityEvent OnClick => _quitButton.onClick;
}
