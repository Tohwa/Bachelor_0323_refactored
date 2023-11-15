using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations
{
    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
