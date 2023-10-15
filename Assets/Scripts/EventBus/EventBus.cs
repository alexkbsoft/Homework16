using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public struct CustomEvent
{
    public CustomEvent(object val = null) {
        Value = val;
    }
    public object Value;
}

public class EventBus
{
    private static Dictionary<string, UnityAction<CustomEvent>> delegates = new();

    public static void AddListener(string key, UnityAction<CustomEvent> callback)
    {
        if (!delegates.ContainsKey(key)) {
            delegates[key] = callback;
        } else {
            delegates[key] += callback;
        }
    }
    public static void RemoveListener(string key, UnityAction<CustomEvent> callback)
    {
        delegates[key] -= callback;
    }

    public static void Invoke(string key, CustomEvent customEv) {
        delegates[key]?.Invoke(customEv);
    }
}