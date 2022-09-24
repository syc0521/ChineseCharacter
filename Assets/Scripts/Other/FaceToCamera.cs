using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start() 
    {
        mainCamera=Camera.main;    
    }


    private void Update() 
    {
        transform.forward=mainCamera.transform.forward;
    }
}
