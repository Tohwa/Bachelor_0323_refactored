using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoatController : MonoBehaviour
{
    public GameObject target;

    public FloatReference speed;
    public FloatReference damage;
    public FloatReference attackDelay;

    public bool canAttack;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine GoatStateMachine { get; private set; }

    public GoatLocateState LocateTargetState { get; private set; }
    public GoatAttackState AttackState { get; private set; }
    public GoatChaseState ChaseState { get; private set; }

    private void Awake()
    {
        GoatStateMachine = new StateMachine();

        LocateTargetState = new GoatLocateState(this, GoatStateMachine);
        ChaseState = new GoatChaseState(this, GoatStateMachine);
        AttackState = new GoatAttackState(this, GoatStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;

        GoatStateMachine.InitGoatState(LocateTargetState);
    }

    private void Update()
    {
        GoatStateMachine.goatState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        GoatStateMachine.goatState.PhysicsUpdate();
    }

    public IEnumerator AttackDelay()
    {
        target.GetComponent<PlayerHealth>().health.Value -= damage.Value;

        canAttack = false;
        yield return new WaitForSeconds(attackDelay.Value);
        canAttack = true;
    }
}
