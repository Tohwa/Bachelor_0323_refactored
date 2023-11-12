using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatReference health;

    private void Update()
    {
        if (health.Value <= 0)
        {
            gameObject.SetActive(false);
            //GameEvent GameOver
        }
    }
}


