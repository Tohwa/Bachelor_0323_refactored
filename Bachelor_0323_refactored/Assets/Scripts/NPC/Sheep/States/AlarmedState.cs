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
        sheep.transform.GetChild(8).gameObject.SetActive(true);
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
    }

    public override void PhysicsUpdate()
    {
        
    }
}
