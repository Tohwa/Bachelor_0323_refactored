using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        if (goblin.target.CompareTag("WeakFencePart") || goblin.target.CompareTag("SolidFencePart") || goblin.target.CompareTag("StrongFencePart"))
        {
            if (goblin.timer <= 0)
            {
                goblin.timer = 0;

                goblin.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= goblin.damage.Value;
                
                int rnd = Random.Range(0, goblin.goblinSteps.Clips.Length);

                goblin.SFXSource.clip = goblin.goblinAttack.Clips[rnd];
                goblin.SFXSource.Play();

                Debug.Log("Attacking Fence");

                if (goblin.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp <= 0)
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
        else if (goblin.target.CompareTag("Sheep") && goblin.Agent.remainingDistance <= goblin.Agent.stoppingDistance)
        {
            if (goblin.timer <= 0)
            {
                goblin.timer = 0;

                goblin.target.GetComponent<SheepHealth>().hp -= goblin.damage.Value;

                int rnd = Random.Range(0, goblin.goblinSteps.Clips.Length);

                goblin.SFXSource.clip = goblin.goblinAttack.Clips[rnd];
                goblin.SFXSource.Play();

                Debug.Log("Attacking Sheep");

                if (goblin.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    goblin.target = null;
                    goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
                }
                else
                {
                    goblin.timer = goblin.attackDelay.Value;
                    goblin.timer -= Time.deltaTime;
                }
            }

            if (goblin.Distance(goblin.transform.position, goblin.target.transform.position) >= goblin.Agent.stoppingDistance)
            {
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.ChaseState);
            }
        }

    }


    public override void PhysicsUpdate()
    {

    }
}
