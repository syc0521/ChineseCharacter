using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    Null = 0, Verb = 1, Noun = 2
}
public class Util : MonoBehaviour
{
    public static void Swap<T>(ref T a, ref T b)
    {
        (a, b) = (b, a);
    }
}
