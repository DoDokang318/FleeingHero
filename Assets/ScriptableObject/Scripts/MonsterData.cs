using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterData", menuName = "NPC/Monster")]
public class MonsterData : ScriptableObject
{
    [field: SerializeField] public float PlayerChasingRange { get; private set; } = 10f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1.5f;
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int HP { get;  set; }
    [field: SerializeField] public float Speed { get; private set; } = 1.5f;
}
