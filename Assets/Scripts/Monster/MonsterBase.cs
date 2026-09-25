using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBase : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private Pattern _currentPattern;
    
    [field: SerializeField] public float MoveSpeed { get; private set; }

    private Patrol _patrol;
    private Chase _chase;
    private Attack _attack;
    
    // [SerializeField] private Animator _animator;


    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // --------------------

    public GameObject Gameobject { get => gameObject; }

    private void CacheComponents()
    {
        _patrol = GetComponent<Patrol>();
        _chase = GetComponent<Chase>();
        
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
        _patrol.CalculateStartPosition();
    }

    public void ChangeAttackPattern()
    {
        _currentPattern = GetComponent<Attack>();
    }
}
