using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCheck : MonoBehaviour
{
    private bool wasActivated = false;

    public bool WasActivated
    {
        get { return wasActivated; }
    }

    public void SetActivated()
    {
        wasActivated = true;
    }
}
