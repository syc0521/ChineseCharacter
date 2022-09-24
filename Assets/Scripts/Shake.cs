using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{

    private Tween tween;
    private float angle = 15;

    private float time = 0.5f;

    private float offset=0.2f;

    public int type = 1;
    
    public bool canShake;


    private void Start()
    {
        canShake=true;
        switch (type)
        {
            case 1:
                tween = transform.DOPunchRotation(new Vector3(0, angle, 0), time);
                break;

            case 2:
                tween = transform.DOPunchPosition(new Vector3(0, offset, 0), time);
                break;
        }

        tween.SetAutoKill(false);
        tween.Pause();

    }

    public void ShakeSelf()
    {
        if(!canShake) return;
        if (tween != null && tween.IsPlaying()) return;
        tween.Restart();
        AkSoundEngine.PostEvent("Play_Shake_Effect", gameObject);
    }
}
