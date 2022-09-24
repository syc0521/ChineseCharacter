using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoolOrgan : BaseOrgan
{
    public GameObject water;
    private bool isUp = true;
    private float initY;
    public string testStr;
    void Start()
    {
        initY = water.transform.localScale.y;
    }

    void Update()
    {
        
    }
    public override void Work(int curElementID)
    {
        throw new System.NotImplementedException();
    }
    [ContextMenu("WaterAnimation")]
    public void WaterAnimation()
    {
        if (isUp)
        {
            isUp = false;
            transform.DOScaleY(0, 1.0f);
        }
        else
        {
            isUp = true;
            transform.DOScaleY(initY, 1.0f);
        }
    }
    [ContextMenu("PlayAudio")]
    public void PlayAudio()
    {
        AkSoundEngine.PostEvent("Play_Pickup_Effect", gameObject);
    }

    [ContextMenu("PlayTestAudio")]
    public void PlayTestAudio()
    {
        AkSoundEngine.PostEvent(testStr, gameObject);

    }

}
