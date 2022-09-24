using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public float speed=1f;
    private int direction;
    void Start()
    {
        direction = Random.Range(0,1)>0.5f?1:-1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,direction*speed*Time.deltaTime);        
    }
}
