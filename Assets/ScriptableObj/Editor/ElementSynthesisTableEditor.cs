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
[CustomEditor(typeof(ElementSynthesisTable))]
public class ElementSynthesisTableEditor : BaseExcelEditor<ElementSynthesisTable>
{	    
    public override bool Load()
    {
        ElementSynthesisTable targetData = target as ElementSynthesisTable;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<ElementSynthesisTableData>().ToArray();
            targetData.dataList = query.Deserialize<ElementSynthesisTableData>();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
