using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BaseState
{
    public BossAttackState(BossController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        if (boss.target.CompareTag("WeakFencePart") || boss.target.CompareTag("SolidFencePart") || boss.target.CompareTag("StrongFencePart"))
        {
            if (boss.timer <= 0)
            {
                boss.timer = 0;

                boss.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= boss.damage.Value;
                Debug.Log("Attacking Fence");

                if (boss.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp <= 0)
                {
                    boss.target = null;
                    boss.BossStateMachine.ChangeBossState(boss.LocateTargetState);
                }
                else
                {
                    boss.timer = boss.attackDelay.Value;
                }
            }
        }
        else if (boss.target.CompareTag("Sheep") && boss.Agent.remainingDistance <= boss.Agent.stoppingDistance)
        {
            if (boss.timer <= 0)
            {
                boss.timer = 0;

                boss.target.GetComponent<SheepHealth>().hp -= boss.damage.Value;

                Debug.Log("Attacking Sheep");

                if (boss.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    boss.target = null;
                    boss.BossStateMachine.ChangeBossState(boss.LocateTargetState);
                }
                else
                {
                    boss.timer = boss.attackDelay.Value;
                    boss.timer -= Time.deltaTime;
                }
            }

            if (boss.Distance(boss.transform.position, boss.target.transform.position) >= boss.Agent.stoppingDistance)
            {
                boss.BossStateMachine.ChangeBossState(boss.ChaseState);
            }
        }

    }

    public override void PhysicsUpdate()
    {

    }
}
