using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarChaseState : BaseState
{
    public BoarChaseState(BoarController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        boar.Agent.SetDestination(boar.target.transform.position);
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        if (!boar.Agent.pathPending)
        {
            if (boar.Agent.remainingDistance <= boar.Agent.stoppingDistance)
            {
                if (!boar.Agent.hasPath || boar.Agent.velocity.sqrMagnitude == 0f)
                {
                    boar.BoarStateMachine.ChangeBoarState(boar.AttackState);
                    boar.Agent.ResetPath();
                }
            }
        }
        else if (boar.target == null)
        {
            boar.BoarStateMachine.ChangeBoarState(boar.LocateTargetState);
            boar.Agent.ResetPath();
        }
    }

    public override void PhysicsUpdate()
    {
        boar.Agent.SetDestination(boar.target.transform.position);
    }
}
