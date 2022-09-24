using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseOrgan : MonoBehaviour
{
   public int[] needID;
   public int UITipID=-1;

    public bool finishWork=false;


   public abstract void Work(int curElementID);
}
