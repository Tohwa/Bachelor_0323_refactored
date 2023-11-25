using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChaseState : BaseState
{
    public GoblinChaseState(GoblinController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        goblin.Agent.SetDestination(goblin.target.transform.position);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (!goblin.Agent.pathPending)
        {
            if (goblin.Agent.remainingDistance <= goblin.Agent.stoppingDistance)
            {
                if (!goblin.Agent.hasPath || goblin.Agent.velocity.sqrMagnitude == 0f)
                {
                    goblin.GoblinStateMachine.ChangeGoblinState(goblin.AttackState);
                }
            }
        }
        else if (wolf.target == null)
        {
            goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
    
