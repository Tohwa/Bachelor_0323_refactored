using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    public bool canAttack = true;
    public FloatReference damage;
    public FloatReference delay;

    private WolfController controller;

    private void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<WolfController>();
        }
    }

    public IEnumerator AttackDelay()
    {
        if (controller.fenceSet.Items.Count != 0)
        {
            controller.target.gameObject.GetComponent<FenceDurability>().durability.Value -= damage.Value;
        }
        else if (controller.fenceSet.Items.Count == 0 && controller.sheepSet.Items.Count != 0)
        {
            controller.target.gameObject.GetComponent<SheepHealth>().health.Value -= damage.Value;
        }

        canAttack = false;
        yield return new WaitForSeconds(delay.Value);
        canAttack = true;
    }
}
