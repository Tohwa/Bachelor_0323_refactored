using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TreeLogging : MonoBehaviour
{
    public GameEvent startLoggingEvent;
    public GameEvent stopLoggingEvent;

    public UnityEvent startResponse;
    public UnityEvent stopResponse;

    public bool canLogTree;
    public bool hitTree;


    private void Update()
    {
        if (canLogTree && hitTree)
        {
            StartLogTree();
        }
        else
        {
            StopLogTree();
        }
    }

    public void HitTree(InputAction.CallbackContext ctx)
    {
        hitTree = ctx.performed;
    }

    public void CanLogTree()
    {
        canLogTree = true;
    }

    public void CanNotLogTree()
    {
        canLogTree= false;
    }

    public void StartLogTree()
    {
        startLoggingEvent.Raise();
    }

    public void StopLogTree()
    {
        stopLoggingEvent.Raise();
    }
}
