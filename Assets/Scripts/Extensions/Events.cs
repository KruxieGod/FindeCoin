
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class Events
{
    public static List<Func<string>> OnPlayerResultMatch { get; private set; } = new();
    public static UnityEvent<bool> OnLose { get; private set; } = new();
}