using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class ElementSynthesisTableAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/ScriptableObj/ElementTable.xlsx";
    private static readonly string assetFilePath = "Assets/ScriptableObj/ElementSynthesisTable.asset";
    private static readonly string sheetName = "ElementSynthesisTable";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            ElementSynthesisTable data = (ElementSynthesisTable)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ElementSynthesisTable));
            if (data == null) {
                data = ScriptableObject.CreateInstance<ElementSynthesisTable> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<ElementSynthesisTableData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<ElementSynthesisTableData>().ToArray();
                data.dataList = query.Deserialize<ElementSynthesisTableData>();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
