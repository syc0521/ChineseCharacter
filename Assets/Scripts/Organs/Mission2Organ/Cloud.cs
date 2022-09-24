using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private List<Material> materials=new();
    public ParticleSystem rain;
    public Transform cloudPos;
    void Start()
    {
        rain.Stop();
        var meshRenderers=GetComponentsInChildren<MeshRenderer>();
        foreach(var v in meshRenderers)
        {
            materials.Add(v.material);
        }
    }
    public void CloudAnimation(float time)
    {
        transform.DOMove(cloudPos.position, time);
        materials.ForEach(v => v.DOFloat(1, Shader.PropertyToID("_RainSlider"), 1f));
        Invoke(nameof(Rain), time);
    }
    private void Rain()
    {
        rain.Play();
        AkSoundEngine.PostEvent("Play_Rain_Effect", gameObject);
    }
    private void OnDestroy()
    {
        AkSoundEngine.PostEvent("Stop_Rain_Effect", gameObject);
    }
}
