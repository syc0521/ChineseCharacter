using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosourceEvent : MonoBehaviour
{
    public string playEvent, stopEvent;
    void Start()
    {
        AkSoundEngine.PostEvent(playEvent, gameObject);
    }
    private void OnDestroy()
    {
        AkSoundEngine.PostEvent(stopEvent, gameObject);
    }
}
