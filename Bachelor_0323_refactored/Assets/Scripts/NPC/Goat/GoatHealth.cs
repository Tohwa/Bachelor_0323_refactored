using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoatHealth : MonoBehaviour
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
