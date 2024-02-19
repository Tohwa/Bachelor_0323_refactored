using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmedState : BaseState
{
    public AlarmedState(SheepController _ally, StateMachine _stateMachine) : base(_ally, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("alarm");

        sheep.Agent.ResetPath();
        sheep.Agent.speed = 15f;
        sheep.Agent.acceleration = 50f;
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        if(sheep.escape)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.EscapeState);
        }
        else if(sheep.fenceSet.Items.Count > 0)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.CozyState);
        }
        else if(sheep.journeyHome)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.ReturnState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
