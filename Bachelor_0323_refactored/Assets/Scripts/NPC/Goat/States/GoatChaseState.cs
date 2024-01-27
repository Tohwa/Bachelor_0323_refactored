using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatChaseState : BaseState
{
    public GoatChaseState(GoatController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        goat.Agent.SetDestination(goat.target.transform.position);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (!goat.Agent.pathPending)
        {
            if (goat.Agent.remainingDistance <= goat.Agent.stoppingDistance)
            {
                if (!goat.Agent.hasPath || goat.Agent.velocity.sqrMagnitude == 0f)
                {
                    goat.GoatStateMachine.ChangeGoatState(goat.AttackState);
                    goat.Agent.ResetPath();
                }
            }
        }
        else if (goat.target == null)
        {
            goat.GoatStateMachine.ChangeGoatState(goat.LocateTargetState);
            goat.Agent.ResetPath();
        }
    }

    public override void PhysicsUpdate()
    {
        goat.Agent.SetDestination(goat.target.transform.position);
    }
}
