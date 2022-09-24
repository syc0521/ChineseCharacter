using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformOrgan : BaseOrgan
{
    public Transform des;
  
    public override void Work(int curElementID)
    {
       transform.DOMove(des.position,2f);
    }
}
