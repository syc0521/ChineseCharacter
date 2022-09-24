using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NounGenerateTable", menuName = "ScriptableObjs/NounGenerateTable")]
public class NounGenerateTable : ScriptableObject
{
    public Dictionary<int,GameObject> nounGenerateDir=new Dictionary<int,GameObject>();

    [System.Serializable]
    public struct NounGenerateStruct
    {
        public int elementID;
        public GameObject elementGeneratePrefab;
    }

    [Header("元素ID 该元素生成的物体")]
    public NounGenerateStruct[] nounGenerateStructs;

    private void OnEnable() 
    {
        foreach (var v in nounGenerateStructs)
        {
            if(!nounGenerateDir.ContainsKey(v.elementID))
            {
                nounGenerateDir.Add(v.elementID,v.elementGeneratePrefab);
            }
        }
    }
}
