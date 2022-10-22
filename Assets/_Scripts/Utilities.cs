using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    
    public static T Instance {
        get
        {
            if (instance != null)
                return instance;
            
            instance = FindObjectOfType<T>();
            
            if(instance)
                return instance;
            
            Debug.LogError($"Cannot find singleton of type {typeof(T)}!");
            return null;
        }
    }
}

public static class Utilities
{
    public static TimeSpan Sec(this float seconds)
    {
        return TimeSpan.FromSeconds(seconds);
    }
}