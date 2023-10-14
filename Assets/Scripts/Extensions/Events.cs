
using UnityEngine.Events;

public class Events
{
    public static UnityEvent<bool> OnCollectedCoin { get; private set; } = new();
}