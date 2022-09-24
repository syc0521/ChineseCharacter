using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using DG.Tweening;

public class LogoController : MonoBehaviour
{
    private VideoPlayer player;
    public SpriteRenderer black;
    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        player.Prepare();
    }
    void Start()
    {
        StartCoroutine(PlayVideo());
        Invoke(nameof(PlayVideo), 0.45f);
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(0.45f);
        DOTween.To(() => 0f, x => player.targetCameraAlpha = x, 1f, 0.32f).SetEase(Ease.InSine);
        AkSoundEngine.PostEvent("Play_Logo", gameObject);
        yield return new WaitForSeconds(0.15f);
        player.Play();
        player.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vp)
    {
        DOTween.Sequence().AppendInterval(0.5f).Append(
            DOTween.To(() => 1f, x => player.targetCameraAlpha = x, 0f, 0.32f).SetEase(Ease.OutSine))
            .AppendInterval(0.5f)
            .OnComplete(() => { SceneManager.LoadScene("StartScene"); });

    }

    void Update()
    {
        
    }
}
