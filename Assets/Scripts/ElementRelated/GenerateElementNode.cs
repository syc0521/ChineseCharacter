using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateElementNode : MonoBehaviour
{
    public int GenerateID;
    void Start()
    {
        GameObject.FindWithTag("SceneNode").GetComponent<SceneNode>().OnInitOverSceneEvent += () =>
        {
            ElementController.Instance.GenerateElementByID(GenerateID, transform.position);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }


}
