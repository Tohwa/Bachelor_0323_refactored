using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CozyState : BaseState
{
    public CozyState(SheepController _ally, StateMachine _stateMachine) : base(_ally, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Cozy!");
        sheep.transform.GetChild(8).gameObject.SetActive(false);
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        if(sheep.fenceSet.Items.Count == 0)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.AlarmedState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
