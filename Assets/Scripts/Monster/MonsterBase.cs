using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Patrol,
    Tracking,
    Attack
}

public class MonsterBase : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private Pattern _currentPattern;
    // [SerializeField] private Animator _animator;
    [field: SerializeField] public float moveSpeed { get; protected set; }
    
    private MonsterState _monsterstate;
    private int _patrolIndex;

    
    private void Patrol()
    {
        _currentPattern.OnAction();
    }
    
    // IAttackable - Attack 구현
}
