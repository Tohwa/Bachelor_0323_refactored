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
                if (!goblin.Agent.hasPath || goblin.Agent.velocity.sqrMagnitude == 0f)
                {
                    goblin.GoblinStateMachine.ChangeGoblinState(goblin.AttackState);
                    goblin.Agent.ResetPath();
                }
            }
        }
        else if (goblin.target.CompareTag("Sheep") && goblin.Agent.remainingDistance <= goblin.Agent.stoppingDistance * 2)
        {
            goblin.timer -= Time.deltaTime;

            if (goblin.timer <= 0)
            {
                goblin.timer = 0;

                goblin.target.GetComponent<SheepHealth>().hp -= goblin.damage.Value;

                Debug.Log("Attacking Sheep");

                if (goblin.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    goblin.target = null;
                    goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
                }
                else
                {
                    goblin.timer = goblin.attackDelay.Value;
                }

            }
        }
        else if (goblin.target == null)
        {
            goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
            goblin.Agent.ResetPath();
        }
    }

    public override void PhysicsUpdate()
    {
        goblin.Agent.SetDestination(goblin.target.transform.position);
    }
}
    
