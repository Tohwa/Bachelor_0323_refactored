using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatReference health;
    public StringReference healthName;  //exits for test purpose will be removed in a bit
    public IntReference healthLevel;    //exits for test purpose will be removed in a bit

    private void Update()
    {
        if (health.Value <= 0)
        {
            gameObject.SetActive(false);
            //GameEvent GameOver
        }
    }
}


