using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityQuickSheet;
using System.Linq;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(ElementTable))]
public class ElementTableEditor : BaseExcelEditor<ElementTable>
{	    
    public override bool Load()
    {
        ElementTable targetData = target as ElementTable;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<ElementTableData>().ToArray();
            targetData.dataList = query.Deserialize<ElementTableData>();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
