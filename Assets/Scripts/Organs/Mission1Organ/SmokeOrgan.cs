using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeOrgan : BaseOrgan
{
    public ParticleSystem smokeParticle;
    public string effectName;


    private void Start()
    {
        smokeParticle.Stop();
    }

    public override void Work(int curElementID)
    {
        if (effectName != "")
            AkSoundEngine.PostEvent(effectName, gameObject);
        smokeParticle.Play();
        GameController.Instance.TaskSuccess(UITipID);
    }
    private void OnDestroy()
    {
        AkSoundEngine.PostEvent("Stop_Smoke_Effect", gameObject);
    }
    [ContextMenu("Test")]
    public void Test()
    {
        if (effectName != "")
            AkSoundEngine.PostEvent(effectName, gameObject);
        smokeParticle.Play();
    }
}
