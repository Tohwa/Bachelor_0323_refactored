using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{
    public FloatReference health;

    [HideInInspector] public float hp;
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
        }
    }
}
