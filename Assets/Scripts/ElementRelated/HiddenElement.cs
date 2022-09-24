using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HiddenElement : MonoBehaviour
{
    public int elementID;
    private TextMeshPro textMeshPro;
    public Transform generateTrans;
    private Vector3 offset;
 
    private bool hasDisClose;
    public bool cantDisClose;

    void Start()
    {
        hasDisClose = false;
        textMeshPro=GetComponentInChildren<TextMeshPro>();
        textMeshPro.text=ElementController.Instance.elementTable.dataArray[elementID].Name;
        offset=new Vector3(0,4f,0);        
    }

    public void Disclose()
    {
        if (hasDisClose||cantDisClose) return;
        hasDisClose = true;
        Destroy(textMeshPro.gameObject);
        GameObject elementObj=ElementController.Instance.GenerateElementByID(elementID,transform.position);
        var curPos=elementObj.transform.position;
        elementObj.transform.DOLocalMove(curPos+offset,0.3f).onComplete+=()=>
        {
            elementObj.transform.DOLocalMove(generateTrans.position,0.6f).onComplete+=()=>Destroy(gameObject);
        };
    }
}
