using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlineController : Singleton<OutlineController>
{
    public OutlineDictionary outlineDictionary;
    public Material outlineMat;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetOutline(int id)
    {
        if (!outlineDictionary.ContainsKey(id)) return;
        var meshRenderers = outlineDictionary[id].GetComponentsInChildren<MeshRenderer>();
        foreach (var item in meshRenderers)
        {
            var mat = item.material;
            Material[] materials = { mat, outlineMat };
            item.materials = materials;
        }
    }

    public void SetNormal(int id)
    {
        if (!outlineDictionary.ContainsKey(id)) return;
        var meshRenderers = outlineDictionary[id].GetComponentsInChildren<MeshRenderer>();
        foreach (var item in meshRenderers)
        {
            var mat = item.materials;
            Material[] materials = { mat[0] };
            item.materials = materials;
        }
    }
}

[Serializable]
public class OutlineDictionary : SerializableDictionary<int, GameObject> { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(OutlineDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
#endif

