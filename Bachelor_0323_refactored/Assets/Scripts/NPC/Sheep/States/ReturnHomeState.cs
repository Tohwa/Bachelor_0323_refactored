using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeState : BaseState
{
    public ReturnHomeState(SheepController _ally, StateMachine _stateMachine) : base(_ally, _stateMachine)
    {
    }

    public override void EnterState()
    {
        sheep.Agent.ResetPath();
        Vector3 newPos = sheep.RandomNavSphere(sheep.cage.transform.position, sheep.wanderRadius.Value, 3);
        sheep.Agent.SetDestination(sheep.oriPos);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (!sheep.Agent.pathPending)
        {
            if (sheep.Agent.remainingDistance <= sheep.Agent.stoppingDistance)
            {
                if (!sheep.Agent.hasPath || sheep.Agent.velocity.sqrMagnitude == 0f)
                {
                    sheep.SheepStateMachine.ChangeSheepState(sheep.AlarmedState);

                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
