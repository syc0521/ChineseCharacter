using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipUIController : Singleton<TipUIController>
{
    public GameObject tipUIPanel;

    private Image[] tipImage;
    void Start()
    {
        tipImage=tipUIPanel.GetComponentsInChildren<Image>();
    }

    public void TipSuccess(int ID)
    {
        if(ID==-1) return;
        tipImage[ID].color=Color.black;
    }

}
