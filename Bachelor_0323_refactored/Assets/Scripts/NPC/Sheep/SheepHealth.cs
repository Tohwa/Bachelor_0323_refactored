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
            gameObject.SetActive(false);
            //remove from active enemy List -- look up Video on discord talk03/23
        }
    }
}
