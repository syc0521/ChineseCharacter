using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertElementObj : MonoBehaviour
{
    public int convertElementID;

    private Vector3 offset;

    void Start()
    {
        offset=new Vector3(0,1.5f,0);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void Convert()
    {
        Destroy(gameObject);
        ElementController.Instance.GenerateElementByID(convertElementID,gameObject.transform.position+offset);
    }
}
