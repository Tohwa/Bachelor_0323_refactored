using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAttackState : BaseState
{
    public BoarAttackState(BoarController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        boar.StartCoroutine(boar.AttackDelay());

        if (boar.target.CompareTag("Environment"))
        {
            if (boar.fenceSet.Items.Count == 0)
            {
                boar.StopCoroutine(boar.AttackDelay());
                boar.target = null;
                boar.BoarStateMachine.ChangeBoarState(boar.LocateTargetState);
            }
        }
        else if (boar.target.CompareTag("Sheep"))
        {
            if (boar.target.GetComponent<SheepHealth>().health.Value <= 0)
            {
                boar.StopCoroutine(boar.AttackDelay());
                boar.target = null;
                boar.BoarStateMachine.ChangeBoarState(boar.LocateTargetState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
