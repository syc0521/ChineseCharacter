using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>:MonoBehaviour where T:Singleton<T>,new()
{
    private static T _Instance;
    public static T Instance {get{return _Instance;}}
  
    private void Awake() 
    {
        //if(_Instance == null)
        //{
        //    _Instance=(T)this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        _Instance=(T)this;
        OnAwake();
    }

    public virtual void OnAwake()
    {

    }
}
