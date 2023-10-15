using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : GUI
{
    [SerializeField] private Slider _hpBarSlider;

    public void SetSliderValue(float value) => _hpBarSlider.value = value;
}
