using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDurability : MonoBehaviour
{
    public FloatReference durability;
    public FloatReference damageTimer;

    public bool gettingHit;

    [HideInInspector] public float hp;
    [HideInInspector] public float timer;

    private void Start()
    {
        hp = durability.Value;
        timer = damageTimer.Value;
    }

    private void Update()
    {
        if (gettingHit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                hp -= 1;
                timer = damageTimer.Value;
            }
        }
        else
        {
            timer = damageTimer.Value;
        }

        if (hp <= 0)
        {
            hp = 0;

            gameObject.SetActive(false);
        }
    }

    public void TreeGettingHit()
    {
        gettingHit = true;
    }

    public void TreeNotGettingHit()
    {
        gettingHit = false;
    }
}
