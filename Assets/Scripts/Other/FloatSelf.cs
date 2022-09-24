using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatSelf : MonoBehaviour
{
    public float offset = 3f;
    private bool playForward;
    private Tween tween;
    public float tweenTime = 1.5f;
    private float startY;
    void Start()
    {
        //var startY=transform.position.y;
        //tween = transform.DOLocalMoveY(startY + offset, tweenTime);
        //tween.SetAutoKill(false);        
        //tween.OnStepComplete(() =>
        //{
        //    if(playForward)
        //    {
        //        tween.PlayForward();
        //    }
        //    else
        //    {
        //        tween.PlayBackwards();
        //    }
        //    playForward = !playForward;
        //}); 
    }

    private void OnEnable()
    {
        playForward = false;
        startY = transform.localPosition.y;
        tween = transform.DOLocalMoveY(startY + offset, tweenTime);
        tween.SetAutoKill(false);
        tween.OnStepComplete(() =>
        {
            if (playForward)
            {
                tween.PlayForward();
            }
            else
            {
                tween.PlayBackwards();
            }
            playForward = !playForward;
        });
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);
        tween.Kill();
    }
}
