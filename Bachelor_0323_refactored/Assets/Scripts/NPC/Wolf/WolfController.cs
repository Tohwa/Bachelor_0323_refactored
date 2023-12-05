using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{
    public GameObject target;

    public FloatReference speed;
    public FloatReference damage;
    public FloatReference attackDelay;

    public bool canAttack;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine WolfStateMachine { get; private set; }

    public WolfLocateState LocateTargetState { get; private set; }
    public WolfAttackState AttackState { get; private set; }
    public WolfChaseState ChaseState { get; private set; }

    public GameObjectSet sheepSet;
    public GameObjectSet fenceSet;

    private void Awake()
    {
        WolfStateMachine = new StateMachine();

        LocateTargetState = new WolfLocateState(this, WolfStateMachine);
        ChaseState = new WolfChaseState(this, WolfStateMachine);
        AttackState = new WolfAttackState(this, WolfStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;

        WolfStateMachine.InitWolfState(LocateTargetState);
    }

    private void Update()
    {
        WolfStateMachine.wolfState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        WolfStateMachine.wolfState.PhysicsUpdate();
    }

    public IEnumerator AttackDelay()
    {
        if (target.CompareTag("Environment"))
        {
            target.transform.parent.transform.parent.GetComponent<FenceDurability>().durability.Value -= damage.Value;
        }
        else if (target.CompareTag("Sheep"))
        {
            target.GetComponent<SheepHealth>().health.Value -= damage.Value;
        }

        canAttack = false;
        yield return new WaitForSeconds(attackDelay.Value);
        canAttack = true;
    }
}
