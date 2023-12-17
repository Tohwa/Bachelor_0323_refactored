using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FenceBuilder : MonoBehaviour
{
    public GameEvent initFence;
    public UnityEvent Response;

    public void Build()
    {
        initFence.Raise();
    }

    
}
