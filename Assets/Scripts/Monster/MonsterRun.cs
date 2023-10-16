using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRun : MonsterBaseState
{
    public MonsterRun(MonsterStateMachine monsterstateMachine) : base(monsterstateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Monster.AnimationData.RunParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.RunParameterHash);
    }
}
