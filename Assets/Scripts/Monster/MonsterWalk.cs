using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonsterBaseState
{
    public MonsterWalk(MonsterStateMachine monsterstateMachine) : base(monsterstateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Monster.AnimationData.WalkParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.WalkParameterHash);
    }
}
