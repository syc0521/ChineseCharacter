using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class ElementTableAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/ScriptableObj/ElementTable.xlsx";
    private static readonly string assetFilePath = "Assets/ScriptableObj/ElementTable.asset";
    private static readonly string sheetName = "ElementTable";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            ElementTable data = (ElementTable)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ElementTable));
            if (data == null) {
                data = ScriptableObject.CreateInstance<ElementTable> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<ElementTableData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<ElementTableData>().ToArray();
                data.dataList = query.Deserialize<ElementTableData>();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
