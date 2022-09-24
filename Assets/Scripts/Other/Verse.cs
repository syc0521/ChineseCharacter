using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Verse : MonoBehaviour
{
    private TextMeshPro[] textMeshPros;
    public float tweenTime = 1f;

    private void Start()
    {
        textMeshPros = GetComponentsInChildren<TextMeshPro>();
        DisplayText();

        GameController.Instance.OnMissionSuccessEvent += HideText;
    }

    [ContextMenu("Display")]
    private void DisplayText()
    {
        DOVirtual.Color(new Color(0, 0, 0, 0), Color.black, tweenTime, newColor =>
        {
            foreach(var v in  textMeshPros)
            {
                v.color = newColor;
            }
        });
    }

    [ContextMenu("Hide")]
    private void HideText()
    {
        DOVirtual.Color(Color.black, new Color(0, 0, 0, 0), tweenTime, newColor =>
        {
            foreach (var v in textMeshPros)
            {
                v.color = newColor;
            }
        });
    }
}
