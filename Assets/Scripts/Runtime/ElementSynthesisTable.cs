using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

///
/// !!! Machine generated code !!!
///
/// A class which deriveds ScritableObject class so all its data 
/// can be serialized onto an asset data file.
/// 
[System.Serializable]
public class ElementSynthesisTable : ScriptableObject 
{	
    [HideInInspector] [SerializeField] 
    public string SheetName = "";
    
    [HideInInspector] [SerializeField] 
    public string WorksheetName = "";
    
    // Note: initialize in OnEnable() not here.
    public ElementSynthesisTableData[] dataArray;
    public List<ElementSynthesisTableData> dataList;
    public Dictionary<(int,int), int> elementSynthesisDir = new();
    void OnEnable()
    {		
//#if UNITY_EDITOR
        //hideFlags = HideFlags.DontSave;
//#endif
        // Important:
        //    It should be checked an initialization of any collection data before it is initialized.
        //    Without this check, the array collection which already has its data get to be null 
        //    because OnEnable is called whenever Unity builds.
        // 		
        if (dataArray == null)
            dataArray = new ElementSynthesisTableData[0];

        foreach (var v in dataList)
        {
            if (v.Firstid > v.Secondid)
            {
                (v.Firstid, v.Secondid) = (v.Secondid, v.Firstid);
            }
            var pair = (v.Firstid, v.Secondid);
            if (!elementSynthesisDir.ContainsKey(pair))
            {
                elementSynthesisDir.Add(pair, v.Generatedid);
            }
        }
    }
    
    //
    // Highly recommand to use LINQ to query the data sources.
    //

}
