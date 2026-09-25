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


    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // --------------------

    private void CacheComponents()
    {
        
    }

    private void Init()
    {
        ChangePatrolPattern();
    }
    
    public void DoAction()
    {
        _currentPattern.OnAction();
    }

    public void ChangeIdlePattern()
    {
        _currentPattern = GetComponent<Idle>();
    }
    
    public void ChangeChasePattern()
    {
        _currentPattern = GetComponent<Chase>();
    }

    public void ChangePatrolPattern()
    {
        _currentPattern = GetComponent<Patrol>();
    }
    

    
    
    // IAttackable - Attack 구현
}
