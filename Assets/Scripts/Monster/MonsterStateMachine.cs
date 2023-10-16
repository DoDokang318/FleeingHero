using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }
    public PlayerConditions Target { get; private set; }
    public MonsterIdle IdleState { get; }
    public MonsterAttack AttackState { get; }
    public MonsterRun RunState { get; }

    public MonsterWalk WalkState { get; }
    public MonsterStateMachine(Monster monster)
    {
        Monster = monster;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConditions>();

        IdleState = new MonsterIdle(this);
        AttackState = new MonsterAttack(this);
        RunState = new MonsterRun(this);
        WalkState = new MonsterWalk(this);

    }
}
