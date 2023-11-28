using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : BaseState
{
    public GoblinAttackState(GoblinController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        //if (goblin.target.CompareTag("Environment"))
        //{
        //    goblin.target.GetComponent<FenceDurability>().durability.Value -= goblin.damage.Value;

        //    if(goblin.target.GetComponent<FenceDurability>().durability.Value <= 0 )
        //    {
        //        goblin.target = null;
        //        goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
        //    }
        //}
        //else if (goblin.target.CompareTag("Sheep"))
        //{
        //    goblin.target.GetComponent<SheepHealth>().health.Value -= goblin.damage.Value;

        //    if (goblin.target.GetComponent<SheepHealth>().health.Value <= 0)
        //    {
        //        goblin.target = null;
        //        goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
        //    }
        //}


        
    }

    public override void PhysicsUpdate()
    {

    }
}
