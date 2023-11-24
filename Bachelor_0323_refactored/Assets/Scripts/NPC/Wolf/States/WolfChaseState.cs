using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChaseState : BaseState
{
    public WolfChaseState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        wolf.Agent.SetDestination(wolf.target.transform.position);
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}
