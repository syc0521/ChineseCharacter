using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class ElementSynthesisMachine : MonoBehaviour, RangeChecker
{
    public ElementSynthesisTable elementSynthesisTable;

    private List<(int, bool)> insideElementList;

    public Transform generateTrans;

    private bool inRange;

    public Transform panelTrans;

    private bool tweening;

    private float time = 1.5f;

    public TextMeshPro[] textMeshPros;
    public TextMeshPro[] jianTextMeshPros;

    private float waitTime = 4f;

    void Start()
    {
        tweening = false;
        insideElementList = new List<(int, bool)>();
        UpdateText();
        MouseController.Instance.OnMouseLeftCancelledEvent += curElement =>
        {
            if (inRange)
            {
                var ID = curElement.ID;
                var isJian = curElement.isJian;
                insideElementList.Add((ID,isJian));
                UpdateText();
                curElement.DestroySelf();

                if(insideElementList.Count==1)
                {
                    StartCoroutine(WaitNextIE());
                }                
                if (insideElementList.Count >= 2 && !tweening)
                {
                    AkSoundEngine.PostEvent("Play_YanTai_Effect", gameObject);
                    tweening = true;
                    var curRotation = panelTrans.localRotation.eulerAngles;
                    panelTrans.DOLocalRotate(curRotation + new Vector3(0, 180, 0), time / 2).onComplete += () =>
                      {
                          var newRotation = panelTrans.localRotation.eulerAngles;
                          panelTrans.DOLocalRotate(newRotation + new Vector3(0, -180, 0), time / 2).onComplete += () =>
                          {
                              insideElementList.Sort();
                              var pair = (insideElementList[0].Item1, insideElementList[1].Item1);
                              if (elementSynthesisTable.elementSynthesisDir.ContainsKey(pair))
                              {
                                  ElementController.Instance.GenerateElementByID(elementSynthesisTable.elementSynthesisDir[pair], generateTrans.position);
                              }
                              else
                              {
                                  foreach (var v in insideElementList)
                                  {
                                      ElementController.Instance.GenerateElementByID(v.Item1, generateTrans.position);
                                  }
                              }
                              insideElementList.Clear();
                              UpdateText();
                              tweening = false;
                          };
                      };

                }
            }
        };
    }

    private IEnumerator WaitNextIE()
    {
        yield return new WaitForSeconds(waitTime);
        if(!tweening)
        {
            foreach (var v in insideElementList)
            {
                ElementController.Instance.GenerateElementByID(v.Item1, generateTrans.position);
            }
            insideElementList.Clear();
            UpdateText();
        }       
    }

    private void UpdateText()
    {
        for(int i=0;i<textMeshPros.Length;i++)
        {
            textMeshPros[i].text="";
        }
        for (int i = 0; i < jianTextMeshPros.Length; i++)
        {
            jianTextMeshPros[i].text = "";
        }

        if (insideElementList.Count==0) return;        
        for(int i=0;i<insideElementList.Count;i++)
        {
            var pair= ElementController.Instance.GetElementNameAndIsJianByID(insideElementList[i].Item1);
            if(pair.Item2)
            {
                jianTextMeshPros[i].text = pair.Item1;
            }
            else
            {
                textMeshPros[i].text = pair.Item1;
            }
            
        }
    }

    public void AddElement(int elementID,bool isJian)
    {
        insideElementList.Add((elementID,isJian));
    }

    public void SetInRange(bool inRange)
    {
        this.inRange = inRange;
    }
}
