using System.Collections;
using System.Collections.Generic;
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
        wolf.StartCoroutine(wolf.AttackDelay());

        if (wolf.target.CompareTag("Environment"))
        {
            if (wolf.fenceSet.Items.Count == 0)
            {
                wolf.StopCoroutine(wolf.AttackDelay());
                wolf.target = null;
                wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
            }
        }
        else if (wolf.target.CompareTag("Sheep"))
        {
            if (wolf.target.GetComponent<SheepHealth>().health.Value <= 0)
            {
                wolf.StopCoroutine(wolf.AttackDelay());
                wolf.target = null;
                wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        
    }
}
