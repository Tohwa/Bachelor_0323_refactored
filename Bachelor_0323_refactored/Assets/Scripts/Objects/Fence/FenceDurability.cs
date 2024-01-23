using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class FenceDurability : MonoBehaviour
{
    public FloatReference weakDurability;
    public FloatReference solidDurability;
    public FloatReference strongDurability;


    [HideInInspector] public float hp;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (gameObject.CompareTag("Weak") && gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            hp = weakDurability.Value;

        }
        else if (gameObject.CompareTag("Solid") && gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            hp = solidDurability.Value;

        }
        else if (gameObject.CompareTag("Strong") && gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            hp = strongDurability.Value;
        }

        if (hp <= 0)
        {
            hp = 0;

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
