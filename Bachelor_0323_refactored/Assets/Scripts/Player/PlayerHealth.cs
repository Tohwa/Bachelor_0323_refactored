using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatReference health;

    public float hp;

    private void Start()
    {
        hp = health.Value;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            gameObject.SetActive(false);
            //GameEvent GameOver
        }
    }
}


