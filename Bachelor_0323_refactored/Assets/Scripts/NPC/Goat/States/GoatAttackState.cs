using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatAttackState : BaseState
{
    public GoatAttackState(GoatController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if(goat.Agent.remainingDistance <= goat.Agent.stoppingDistance)
        {
            goat.StartCoroutine(goat.AttackDelay());
        }
        else
        {
            goat.StopAllCoroutines();
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
