using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : Singleton<EffectController>
{
    public EffectTable effectTable;
    public delegate void EffectCallback<in T>(T value);

    public void PlayOneShot(string name, Vector3 pos,EffectCallback<GameObject> effectCallback)
    {
        if (effectTable.effectDir.ContainsKey(name))
        {
            GameObject effectPrefab = effectTable.effectDir[name];
            var effectObj = Instantiate(effectPrefab, pos, Quaternion.identity);     
            effectCallback(effectObj);
        }
        else
        {
            return;
        }    
    }

    public void PlayOneShot(string name, Vector3 pos,Quaternion rotation, EffectCallback<GameObject> effectCallback)
    {
        if (effectTable.effectDir.ContainsKey(name))
        {
            GameObject effectPrefab = effectTable.effectDir[name];
            var effectObj = Instantiate(effectPrefab, pos,rotation);
            effectCallback(effectObj);
        }
        else
        {
            return;
        }
    }
}
