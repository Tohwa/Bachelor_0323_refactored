using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : BaseState
{
    public WolfAttackState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Attacking target...");
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
    //    if(wolf.gameObject.GetComponent<WolfAttack>().canAttack && wolf.target != null)
    //    {
    //        Debug.Log("Attacking");
    //        wolf.gameObject.GetComponent<WolfAttack>().StartCoroutine(wolf.gameObject.GetComponent<WolfAttack>().AttackDelay());
    //    }


    //    if (wolf.target.GetComponent<FenceDurability>().durability.Value <= 0 || wolf.target.GetComponent<SheepHealth>().health.Value <= 0)
    //    {
    //        wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
    //    }
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}
