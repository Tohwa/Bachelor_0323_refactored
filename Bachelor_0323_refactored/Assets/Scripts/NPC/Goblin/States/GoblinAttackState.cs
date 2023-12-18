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
        goblin.timer -= Time.deltaTime;

        if (goblin.timer <= 0)
        {
            goblin.timer = 0;

            if (goblin.target.CompareTag("Environment"))
            {
                goblin.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= goblin.damage.Value;
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
    }

    public override void PhysicsUpdate()
    {

    }
}
