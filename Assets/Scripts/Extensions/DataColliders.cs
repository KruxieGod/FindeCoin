
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataColliders
{
    public static Dictionary<Collider, Action<int>> CoinCollection { get; private set; } = new();
    public static Dictionary<Collider, Action<int,Vector3>> OnDamageTake { get; private set; } = new();
}