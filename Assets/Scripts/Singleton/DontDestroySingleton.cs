using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySingleton<T> : MonoBehaviour where T : DontDestroySingleton<T>, new()
{
    private static T _Instance;
    public static T Instance { get { return _Instance; } }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        OnAwake();
    }

    public virtual void OnAwake()
    {

    }
}
