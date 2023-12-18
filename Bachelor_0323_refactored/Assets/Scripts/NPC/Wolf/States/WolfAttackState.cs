using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WolfAttackState : BaseState
{
    public WolfAttackState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Attacking target...");
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        wolf.timer -= Time.deltaTime;

        if (wolf.timer <= 0)
        {
            wolf.timer = 0;

            if (wolf.target.CompareTag("Environment"))
            {
                wolf.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= wolf.damage.Value;
                Debug.Log("Attacking Fence");

                if (wolf.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp <= 0)
                {
                    wolf.target = null;
                    wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
                }
                else
                {
                    wolf.timer = wolf.attackDelay.Value;
                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
