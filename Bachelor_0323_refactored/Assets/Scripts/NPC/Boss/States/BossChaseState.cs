using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : BaseState
{
    public BossChaseState(BossController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        boss.Agent.SetDestination(boss.target.transform.position);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (!boss.Agent.pathPending)
        {
            if (boss.Agent.remainingDistance <= boss.Agent.stoppingDistance)
            {
                if (!boss.Agent.hasPath || boss.Agent.velocity.sqrMagnitude == 0f)
                {
                    boss.BossStateMachine.ChangeBossState(boss.AttackState);
                    boss.Agent.ResetPath();
                }
            }
        }
        else if (boss.target == null)
        {
            boss.BossStateMachine.ChangeBossState(boss.LocateTargetState);
            boss.Agent.ResetPath();
        }
    }

    public override void PhysicsUpdate()
    {
        boss.Agent.SetDestination(boss.target.transform.position);
    }
}
