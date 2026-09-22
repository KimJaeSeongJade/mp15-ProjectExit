using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Patrol, 
    Attack
}

public class MonsterBase : MonoBehaviour, IAttackable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _attackDamage;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> _wayPoints; // 패트롤 포인트 리스트들
    
    private MonsterState _monsterstate;
    private int _patrolIndex;
    
    
    
    private void Patrol()
    {
        
    }
    
    // IAttackable - Attack 구현
}
