
using UnityEngine.Events;

public class Events
{
    public static UnityEvent<bool,string> OnLose { get; private set; } = new();
}