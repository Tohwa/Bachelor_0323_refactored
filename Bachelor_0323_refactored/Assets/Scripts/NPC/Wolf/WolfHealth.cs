using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    public FloatReference health;

    private void Update()
    {
        if(health.Value <= 0)
        {
            gameObject.SetActive(false);
            //remove from active enemy List -- look up Video on discord talk03/23
        }
    }
}
