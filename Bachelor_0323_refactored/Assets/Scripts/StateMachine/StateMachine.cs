using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public BaseState wolfState;
    public BaseState boarState;
    public BaseState goatState;
    public BaseState goblinState;
    public BaseState bossState;

    public BaseState sheepState;

    public BaseState gameState;

    public void InitWolfState(BaseState _startState)
    {
        wolfState = _startState;
        wolfState.EnterState();
    }
    public void InitBoarState(BaseState _startState)
    {
        boarState = _startState;
        boarState.EnterState();
    }
    public void InitGoatState(BaseState _startState)
    {
        goatState = _startState;
        goatState.EnterState();
    }
    public void InitGoblinState(BaseState _startState)
    {
        goblinState = _startState;
        goblinState.EnterState();
    }
    public void InitBossState(BaseState _startState)
    {
        bossState = _startState;
        bossState.EnterState();
    }

    public void InitSheepState(BaseState _startState)
    {
        sheepState = _startState;
        sheepState.EnterState();
    }

    public void InitGameState(BaseState _startState)
    {
        gameState = _startState;
        gameState.EnterState();
    }

    public void ChangeWolfState(BaseState _newState)
    {
        wolfState.ExitState();
        wolfState = _newState;
        wolfState.EnterState();
    }

    public void ChangeBoarState(BaseState _newState)
    {
        boarState.ExitState();
        boarState = _newState;
        boarState.EnterState();
    }
    public void ChangeGoatState(BaseState _newState)
    {
        goatState.ExitState();
        goatState = _newState;
        goatState.EnterState();
    }
    public void ChangeGoblinState(BaseState _newState)
    {
        goblinState.ExitState();
        goblinState = _newState;
        goblinState.EnterState();
    }

    public void ChangeBossState(BaseState _newState)
    {
        bossState.ExitState();
        bossState = _newState;
        bossState.EnterState();
    }
    public void ChangeSheepState(BaseState _newState)
    {
        sheepState.ExitState();
        sheepState = _newState;
        sheepState.EnterState();
    }

    public void ChangeGameState(BaseState _newState)
    {
        gameState.ExitState();
        gameState = _newState;
        gameState.EnterState();
    }
}
