using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOrgan : BaseOrgan
{
    public PoolOrgan waterPool;
    public FieldOrgan field;
    public GameObject grassRoot;
    public Cloud cloud;
    public HiddenElement tian;
    public ParticleSystem evapor;
    public float vaporTime;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void Work(int curElementID)
    {
        StartCoroutine(TreeAnimation());
    }
    [ContextMenu("Work")]

    public void Test()
    {
        StartCoroutine(TreeAnimation());

    }
    private IEnumerator TreeAnimation()
    {
        GameController.Instance.TaskSuccess(UITipID);
        transform.DOLocalRotate(new Vector3(-90, 45, 0), 1f).SetEase(Ease.InCubic)
            .OnComplete(() => AkSoundEngine.PostEvent("Play_TreeDown_Effect", gameObject));
        AkSoundEngine.PostEvent("Play_Cut_Effect", gameObject);
        yield return new WaitForSeconds(1.5f);
        waterPool.OnAnimEndEvent += () => waterPool.transform.DOMoveY(0.2f, 3f);
        waterPool.PoolAnim(0.01f, vaporTime);
        evapor.Play();
        AkSoundEngine.PostEvent("Play_Vapor_Effect", gameObject);
        cloud.transform.DOScale(1.5f, vaporTime);
        yield return new WaitForSeconds(vaporTime);
        evapor.Stop();
        cloud.CloudAnimation(2.0f);
        tian.cantDisClose = false;
        yield return new WaitForSeconds(2.5f);
        if (!field.isRain && field.isWork)
        {
            field.GrowGrains();
        }
        else if (!field.isWork)
        {
            field.isRain = true;
        }
    }


}
