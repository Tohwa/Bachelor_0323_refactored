using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogTriggerBehaviour : MonoBehaviour
{
    public GameEvent TriggerEnterEvent;
    public GameEvent TriggerExitEvent;

    public UnityEvent EnterResponse;
    public UnityEvent ExitResponse;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerEnterEvent.Raise();
        }

        gameObject.transform.parent.transform.parent.GetComponent<TreeDurability>().activeTarget = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerExitEvent.Raise();
        }

        gameObject.transform.parent.transform.parent.GetComponent<TreeDurability>().activeTarget = false;
    }
}
