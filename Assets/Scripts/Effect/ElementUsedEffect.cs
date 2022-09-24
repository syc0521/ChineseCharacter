using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ElementUsedEffect : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    public void Init(string text)
    {
        textMeshPro.text = text; 
    }

    private void Start()
    {
        transform.DOScale(1f, 0.5f).onComplete += () =>
           {
               DOVirtual.Color(Color.white, new Color(255, 255, 255, 0), 1f, newColor =>
                     {
                         textMeshPro.color = newColor;
                     }).onComplete += () =>
                      {
                          Destroy(gameObject);
                      };
           };
        //DOVirtual.Color(Color.white, new Color(255, 255*0.3f, 0, 255), 0.5f, newColor =>
        //      {
        //          textMeshPro.color = newColor;
        //      });
        //transform.DOScale(1f, 0.5f).onComplete += () =>
        //{
        //    Color curColor=textMeshPro.color;
        //    DOVirtual.Color(curColor, new Color(curColor.r,curColor.g,curColor.b,0), 1f, newColor =>
        //    {
        //        textMeshPro.color = newColor;
        //    }).onComplete += () =>
        //    {
        //        Destroy(gameObject);
        //    };
        //};
    }
}
