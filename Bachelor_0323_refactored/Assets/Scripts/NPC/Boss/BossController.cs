using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public GameObject target;

    public FloatReference speed;
    public FloatReference damage;
    public FloatReference attackDelay;

    public float timer;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine BossStateMachine { get; private set; }

    public BossLocateState LocateTargetState { get; private set; }
    public BossAttackState AttackState { get; private set; }
    public BossChaseState ChaseState { get; private set; }

    public GameObjectSet sheepSet;
    public GameObjectSet fenceSet;

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

        BossStateMachine.InitBossState(LocateTargetState);
    }

    private void Update()
    {
        BossStateMachine.bossState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        BossStateMachine.bossState.PhysicsUpdate();
    }
    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
