using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunOrgan : MatchGenerateOrgan
{
    private Transform sunNodeTrans;
    public Vector3 desRotation;

    public Light dirLight;

    public Color desColor;


    private void Start() 
    {
        sunNodeTrans=transform.parent;     
    }

    public override void Work(int curElementID)
    {
        dirLight.DOColor(desColor,2f);
        AkSoundEngine.PostEvent("Play_SunDown_Effect", gameObject);
        sunNodeTrans.DOLocalRotate(desRotation,2f).onComplete+=()=>
        {
            GameController.Instance.TaskSuccess(UITipID);
            if(generatePrefab==null) return;
            //Instantiate(generatePrefab,generateTrans.position,generateTrans.rotation,GameObject.FindWithTag("SceneNode").transform);
            //AudioController.Instance.PlayOneShot("Fire_Effect");
            //AudioController.Instance.PlayOneShot("TreeBurning_Effect");
        };
    }
}
