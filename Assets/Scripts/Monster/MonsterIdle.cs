using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdle : MonsterBaseState
{
    public MonsterIdle(MonsterStateMachine monsterstateMachine) : base(monsterstateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Monster.AnimationData.IdleParmaeterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.IdleParmaeterHash);
    }
}
