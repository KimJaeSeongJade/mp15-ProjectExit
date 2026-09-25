using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Patrol,
    Chase,
    Attack
}

public class MonsterBase : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private Pattern _currentPattern;
    // [SerializeField] private Animator _animator;
    [field: SerializeField] public float MoveSpeed { get; private set; }
    
    private MonsterState _monsterstate;
    private int _patrolIndex;

    
    public void ChangeChasePattern()
    {
        _monsterstate = MonsterState.Chase;
        _currentPattern = GetComponent<Chase>();
        _currentPattern.OnAction();
    }

    public void ChangePatrolPattern()
    {
        _monsterstate = MonsterState.Patrol;
        _currentPattern = GetComponent<Patrol>();
        _currentPattern.OnAction();
    }
    

    
    
    // IAttackable - Attack 구현
}
