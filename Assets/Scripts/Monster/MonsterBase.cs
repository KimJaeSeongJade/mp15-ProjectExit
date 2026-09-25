using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBase : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private Pattern _currentPattern;
    
    [field: SerializeField] public float MoveSpeed { get; private set; }

    private Patrol _Patrol;
    private Chase _Chase;
    
    // [SerializeField] private Animator _animator;


    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // --------------------

    private void CacheComponents()
    {
        _Patrol = GetComponent<Patrol>();
        _Chase = GetComponent<Chase>();
    }

    private void Init()
    {
        ChangePatrolPattern();
    }
    
    public void DoAction()
    {
        _currentPattern.OnAction();
    }
    
    public void ChangeChasePattern()
    {
        _currentPattern = GetComponent<Chase>();
    }

    public void ChangePatrolPattern()
    {
        _currentPattern = GetComponent<Patrol>();
        _Patrol.CalculateStartPosition();
    }
}
