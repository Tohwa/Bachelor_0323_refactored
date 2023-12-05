using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSetInteractor : MonoBehaviour
{
    public GameObjectSet goblinList;

    private void OnEnable()
    {
        goblinList.Add(gameObject);
    }

    private void OnDisable()
    {
        goblinList.Remove(gameObject);
    }
}
