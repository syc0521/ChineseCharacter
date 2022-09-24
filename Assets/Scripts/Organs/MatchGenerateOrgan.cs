using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGenerateOrgan : BaseOrgan
{
    public GameObject generatePrefab;
    public Transform generateTrans;
    public string effectName;

    public override void Work(int curElementID)
    {
        if(effectName!="")
            AkSoundEngine.PostEvent(effectName, gameObject);
        GameController.Instance.TaskSuccess(UITipID);
        Instantiate(generatePrefab,generateTrans.position,generateTrans.rotation,GameObject.FindWithTag("SceneNode").transform);        
    }

    private void Start()
    {
        

    }
}
