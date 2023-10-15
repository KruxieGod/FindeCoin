using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class WinLoseUI : GUI
{
    [field: SerializeField] public ResultUI WinUI { get; private set; }
    [field: SerializeField] public ResultUI LoseUI { get; private set; }
}

