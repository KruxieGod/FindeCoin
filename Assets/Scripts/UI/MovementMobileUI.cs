using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementMobileUI : GUI
{
    [field: SerializeField] public Joystick JoystickView { get; private set; }
    [field: SerializeField] public Joystick JoystickMovement { get; private set; }
    [field: SerializeField] public Button OnFireClick { get; private set; }
}
