using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AdjustSceneSize : Editor
{
    [MenuItem("Tools/NormalSize &%#n", priority = 11)]
    public static void NormalSize()
    {
        var node = GameObject.Find("SceneNode");
        Undo.RegisterCompleteObjectUndo(node, "Changed Size of Node");
        node.transform.localScale = Vector3.one;
    }

    [MenuItem("Tools/SmallSize &%#s", priority = 11)]
    public static void SmallSize()
    {
        var node = GameObject.Find("SceneNode");
        Undo.RegisterCompleteObjectUndo(node, "Changed Size of Node");
        node.transform.localScale = Vector3.one * 0.01f;
    }
}
