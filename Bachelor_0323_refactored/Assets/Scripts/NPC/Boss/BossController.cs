using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public FloatVariable speed;

    public Locator locator;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine BossStateMachine { get; private set; }

    public BossLocateState LocateTargetState { get; private set; }
    public BossAttackState AttackState { get; private set; }
    public BossChaseState ChaseState { get; private set; }

    private void Awake()
    {
        BossStateMachine = new StateMachine();

        LocateTargetState = new BossLocateState(this, BossStateMachine);
        ChaseState = new BossChaseState(this, BossStateMachine);
        AttackState = new BossAttackState(this, BossStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;

        BossStateMachine.InitGoblinState(LocateTargetState);
    }

    private void Update()
    {
        BossStateMachine.bossState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        BossStateMachine.bossState.PhysicsUpdate();
    }
}
