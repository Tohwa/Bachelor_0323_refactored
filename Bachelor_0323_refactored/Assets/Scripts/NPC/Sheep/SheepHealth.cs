using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{
    public FloatReference health;

    private void Update()
    {
        if (health.Value <= 0)
        {
            health.Value = 0;
            gameObject.SetActive(false);
        }
    }
}
