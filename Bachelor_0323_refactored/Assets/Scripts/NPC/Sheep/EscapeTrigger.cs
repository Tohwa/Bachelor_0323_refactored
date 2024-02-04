using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeTrigger : MonoBehaviour
{
    public GameEvent GameEvent;
    public UnityEvent Response;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("BossEnemy"))
        {
            GameEvent.Raise();
        }
    }

}
