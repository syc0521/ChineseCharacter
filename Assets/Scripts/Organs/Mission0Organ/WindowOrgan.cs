using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindowOrgan : BaseOrgan
{
    public Transform left;
    public Transform right;
    public float time;


    public override void Work(int curElementID)
    {
        AkSoundEngine.PostEvent("Play_Open_Effect", gameObject);
        left.DOLocalRotate(new Vector3(0, -130, 0), time);
        right.DOLocalRotate(new Vector3(0, 320, 0), time).onComplete += () =>
        {
            GameController.Instance.TaskSuccess(UITipID);
        };
    }
}
