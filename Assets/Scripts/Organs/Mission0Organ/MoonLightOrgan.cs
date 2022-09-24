using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoonLightOrgan : BaseOrgan
{    
    public Vector3 desRotation;
    private Transform parentTransform;
    public Light directionLight;

    public Color desColor;

    private void Start() 
    {
        parentTransform=transform.parent;   
    }

    public override void Work(int curElementID)
    {
        AkSoundEngine.PostEvent("Play_Time_Effect", gameObject);
        parentTransform.DOLocalRotate(desRotation,3f).onComplete+=()=>
        {
            GameController.Instance.TaskSuccess(UITipID);                
        };

        directionLight.DOColor(desColor,3f);
    }
}
