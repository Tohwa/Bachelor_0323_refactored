using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSetInteractor : MonoBehaviour
{
    public GameObjectSet fenceList;

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.GetComponent<FenceSetInteractor>().enabled = false;
        }
        else if(gameObject.activeSelf)
        {
            gameObject.GetComponent<FenceSetInteractor>().enabled = true;
        }
    }

    private void OnEnable()
    {
        fenceList.Add(gameObject);
    }

    private void OnDisable()
    {
        fenceList.Remove(gameObject);
    }
}
