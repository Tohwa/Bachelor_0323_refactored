using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class BaseState
{
    #region Fields
    protected WolfController wolf;
    protected BoarController boar;
    protected GoatController goat;
    protected GoblinController goblin;
    protected BossController boss;

    protected SheepController sheep;

    protected StateMachine stateMachine;

    //private string animBoolName;
    #endregion

    #region Constructor
    public BaseState(WolfController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        wolf = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(BoarController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        boar = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(GoatController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        goat = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(GoblinController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        goblin = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(BossController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        boss = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(SheepController _enemy, StateMachine _stateMachine/*, String _animBoolName */)
    {
        sheep = _enemy;
        stateMachine = _stateMachine;
        //animBoolName = _animBoolName;
    }

    public BaseState(StateMachine _stateMachine)    //GameState
    {
        stateMachine = _stateMachine;
    }

    #endregion

    #region virtuals
    public virtual void EnterState()
    {
        //player.anim.setBool(animBoolName, true);
        //startTime = Time.time;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void ExitState()
    {
        //player.anim.setBool(animBoolName, false);
    }
    #endregion

}
