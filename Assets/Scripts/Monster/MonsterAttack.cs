using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterBaseState
{
    public MonsterAttack(MonsterStateMachine monsterstateMachine) : base(monsterstateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Monster.AnimationData.AttackParameterName);
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.AttackParameterName);
    }
}
