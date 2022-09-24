using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraBlur : Singleton<CameraBlur>
{
    private Volume volume;
    public override void OnAwake()
    {
        volume = GetComponent<Volume>();
    }
    public void StartCameraBlur()
    {
        if (volume.profile.TryGet(out DepthOfField dof))
        {
            DOTween.To(() => 1f, x => dof.focalLength.value = x, 300f, 0.8f).SetEase(Ease.OutQuad).SetUpdate(true);
        }
    }

    public void StopCameraBlur()
    {
        if (volume.profile.TryGet(out DepthOfField dof))
        {
            DOTween.To(() => 300f, x => dof.focalLength.value = x, 1f, 0.8f).SetEase(Ease.OutQuad).SetUpdate(true);
        }
    }
}
