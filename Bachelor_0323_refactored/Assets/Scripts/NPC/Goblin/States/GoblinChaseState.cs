using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                goblin.Agent.isStopped = true;
                //if (goblin.target.CompareTag("Environment"))
                //{
                //    goblin.Agent.isStopped = true;

                //    goblin.delay -= Time.deltaTime;
                //    if (goblin.delay <= 0)
                //    {
                //        goblin.target.GetComponent<FenceDurability>().durability.Value -= goblin.damage.Value;
                //        goblin.delay = goblin.attackDelay.Value;
                //    }
                //    else if (goblin.target.GetComponent<FenceDurability>().durability.Value <= 0)
                //    {
                //        goblin.target = null;
                //        goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
                //    }
                //}
                //else if (goblin.target.CompareTag("Sheep"))
                //{
                //    goblin.Agent.isStopped = true;

                //    goblin.delay -= Time.deltaTime;
                //    if (goblin.delay <= 0)
                //    {
                //        goblin.target.GetComponent<SheepHealth>().health.Value -= goblin.damage.Value;
                //        goblin.delay = goblin.attackDelay.Value;
                //    }
                //    else if (goblin.target.GetComponent<SheepHealth>().health.Value <= 0)
                //    {
                //        goblin.target = null;
                //        goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
                //    }

                //    if(goblin.Agent.remainingDistance >= goblin.Agent.stoppingDistance)
                //    {
                //        return;
                //    }
                //}
                Debug.Log("In range! Remaining Distance: " + goblin.Agent.remainingDistance);
            }
            
            if(goblin.Agent.remainingDistance >= goblin.Agent.stoppingDistance)
            {
                goblin.Agent.isStopped = false;
                goblin.Agent.ResetPath();
                goblin.Agent.SetDestination(goblin.target.transform.position);
                Debug.Log("Chasing. Remaining Distance: " + goblin.Agent.remainingDistance);
            }
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
    
