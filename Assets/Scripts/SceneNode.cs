using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneNode : MonoBehaviour
{
    public delegate void OnInitOverSceneDelegate();
    public event OnInitOverSceneDelegate OnInitOverSceneEvent;
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Transform_Effect", gameObject);
        transform.DOScale(Vector3.one, 1.5f).onComplete+=()=>
        {
            
            OnInitOverSceneEvent?.Invoke();
        };     
    }

    public void Disappear()
    {
        AkSoundEngine.PostEvent("Play_Transform_Effect", gameObject);
        transform.DOScale(Vector3.one*0.01f, 1.5f).onComplete+=()=>
        {
            Loading.Instance.LoadNextScene();
        };
    }
}
