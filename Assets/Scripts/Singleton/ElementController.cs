using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : Singleton<ElementController>
{
    //元素信息表
    public ElementTable elementTable;
    //名词元素生成表
    public NounGenerateTable nounGenerateTable;
    //单个元素实例
    public GameObject elementPrefab;
    public GameObject elementPrefabJian;
    public Material[] elementMaterials;

    public string GetElementNameByID(int ID)
    {
        var name = "";
        if (Array.Exists(elementTable.dataArray, (item) => item.ID == ID))
            name = elementTable.dataArray[ID].Name;
        return name;
    }

    public (string,bool) GetElementNameAndIsJianByID(int ID)
    {
        var pair = ("", false);
        if (Array.Exists(elementTable.dataArray, (item) => item.ID == ID))
            pair = (elementTable.dataArray[ID].Name, elementTable.dataArray[ID].Isjian);                 
        return pair;
    }

    public GameObject GenerateElementByID(int ID, Vector3 pos)
    {
        if (Array.Exists(elementTable.dataArray, (item) => item.ID == ID))
        {
            AkSoundEngine.PostEvent("Play_Create_Effect", gameObject);
            ElementTableData elementStruct = elementTable.dataArray[ID];
            GameObject temp;
            var jian = elementStruct.Isjian;
            if (jian)
            {
                temp = Instantiate(elementPrefabJian, pos, Quaternion.identity);
            }
            else
            {
                temp = Instantiate(elementPrefab, pos, Quaternion.identity);
            }
            temp.name = elementStruct.Name + "Element";
            Element element = temp.GetComponent<Element>();
            element.SetID(elementStruct.ID);
            element.SetName(elementStruct.Name);
            element.SetType(elementStruct.ElementType);
            element.SetIsJian(elementStruct.Isjian);

            switch(elementStruct.ElementType)
            {
                case ElementType.Null:
                    element.SetMaterial(elementMaterials[0]);
                    break;
                case ElementType.Noun:
                    element.SetMaterial(elementMaterials[1]);
                    break;
                case ElementType.Verb:
                    element.SetMaterial(elementMaterials[2]);
                    break;
            }


            return element.gameObject;
        }
        else
        {
            Debug.LogError("Not Found ID");
            Debug.LogWarning(ID);
        }
        return null;
    }

    public GameObject GenerateElementByName(string name, Vector3 pos)
    {
        int i;
        for (i = 0; i < elementTable.dataList.Count; i++)
        {
            if (elementTable.dataList[i].Name == name)
            {
                break;
            }
        }

        if (i >= elementTable.dataList.Count)
        {
            Debug.LogError("Not Found Name");
        }
        else
        {
            AkSoundEngine.PostEvent("Play_Create_Effect", gameObject);
            ElementTableData elementStruct = elementTable.dataList[i];
            var temp = Instantiate(elementPrefab, pos, Quaternion.identity);
            temp.name = elementStruct.Name + "Element";
            Element element = temp.GetComponent<Element>();
            element.SetID(elementStruct.ID);
            element.SetName(elementStruct.Name);
            element.SetType(elementStruct.ElementType);
            return element.gameObject;
        }
        return null;
    }

    public bool ElementMatchCheck(Element curElement, BaseOrgan curOrgan)
    {
        if (curOrgan.needID.Length == 0) return false;
        if (curOrgan.finishWork) return false;

        foreach (var v in curOrgan.needID)
        {
            if (v == curElement.ID)
            {
                return true;
            }
        }
        return false;
    }

    public void ElementConvert(Element element)
    {
        if (element.type == ElementType.Noun)
        {
            var convertObj = nounGenerateTable.nounGenerateDir[element.ID];
            Instantiate(convertObj, element.transform.position, Quaternion.identity);
        }
    }
}
