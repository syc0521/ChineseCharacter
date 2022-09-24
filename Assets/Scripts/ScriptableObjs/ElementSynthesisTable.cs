using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementSynthesisTable", menuName = "ScriptableObjs/ElementSynthesisTable")]
public class ElementSynthesisTableBack : ScriptableObject
{
   public Dictionary<string,int> elementSynthesisDir=new Dictionary<string,int>();


    [System.Serializable]
    public struct SynthesisStruct
    {
        public int firstElementID;
        public int secondElementID;
        public int generateElementID;
    }

    [Header("组合元素的两个ID 严格按照ID大小填写 组合生成的元素ID")]
    public SynthesisStruct[] synthesisStructs;

   private void OnEnable() 
   {
       foreach(var v in synthesisStructs)
       { 
           string key=v.firstElementID+""+v.secondElementID;
           if(!elementSynthesisDir.ContainsKey(key))
           { 
               elementSynthesisDir.Add(key,v.generateElementID);
           }
       }
   }
}
