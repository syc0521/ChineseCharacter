using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EffectTable",menuName ="ScriptableObjs/EffectTable")]
public class EffectTable : ScriptableObject
{
    public Dictionary<string, GameObject> effectDir = new Dictionary<string, GameObject>();

    [System.Serializable]
    public struct Effect
    {
        public string name;
        public GameObject effectPrefab;
    }

    public Effect[] effects;

    private void OnEnable()
    {
        foreach (var v in effects)
        {
            if (!effectDir.ContainsKey(v.name))
            {
                effectDir.Add(v.name, v.effectPrefab);
            }
        }
    }
}
