using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MonsterAnimation
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string attackParameterName = "Attack";

    public int IdleParmaeterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }

    public int AttackParameterName { get; private set; }

    public void Initialize()
    {
        IdleParmaeterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        AttackParameterName = Animator.StringToHash(attackParameterName);
    }
}
