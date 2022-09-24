using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOrgan : BaseOrgan
{
    public Transform grain, seed;
    public bool isRain = false, isWork = false;
    public override void Work(int curElementID)
    {
        if (isRain)
        {
            GrowGrains();
        }
        else
        {
            ScatterSeeds();
        }
        isWork = true;
    }

    public void GrowGrains()
    {
        seed.gameObject.SetActive(false);
        AkSoundEngine.PostEvent("Play_Grass_Effect", gameObject);
        grain.gameObject.SetActive(true);
        grain.DOScaleY(1.0f, 3.5f).OnComplete(() =>
        {
            GameController.Instance.TaskSuccess(UITipID);
        });
    }

    public void ScatterSeeds()
    {
        AkSoundEngine.PostEvent("Play_Translation_Effect", gameObject);
        seed.gameObject.SetActive(true);
    }
}
