using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoolOrgan : BaseOrgan
{
    private int rockCount;
    public Bird bird;

    public GameObject[] rocks;
    public delegate void AnimEndDelegate();
    public event AnimEndDelegate OnAnimEndEvent;

    private void Start()
    {
        rockCount = 0;
    }

    public override void Work(int curElementID)
    {
        if (rockCount > 1) return;
        if (rockCount == 0)
        {
            rocks[0].SetActive(true);
            AkSoundEngine.PostEvent("Play_StoneInWater_Effect", gameObject);
            PoolAnim(0.7f, 1f);
        }
        else if (rockCount == 1)
        {
            rocks[1].SetActive(true);
            AkSoundEngine.PostEvent("Play_StoneInWater_Effect", gameObject);
            PoolAnim(1.3f, 1f);
            bird.canDrink=true;
            GameController.Instance.TaskSuccess(UITipID);
            finishWork = true;
        }
        rockCount++;
    }

    public void PoolAnim(float des, float duration)
    {
        transform.DOScaleY(des, duration).onComplete += () => OnAnimEndEvent?.Invoke();
    }
}
