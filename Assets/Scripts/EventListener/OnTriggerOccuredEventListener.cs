using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnTriggerOccuredEventListener : MonoBehaviour
{
    public GameObject rootObject = null;
    public delegate void OnTriggerEnterDL(Collider other);
    public event OnTriggerEnterDL OnTriggerEnterEvent;

    public delegate void OnTriggerStayDL(Collider other);
    public event OnTriggerStayDL OnTriggerStayEvent;

    public delegate void OnTriggerExitDL(Collider other);
    public event OnTriggerExitDL OnTriggerExitEvent;


    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitEvent?.Invoke(other);
    }
}
