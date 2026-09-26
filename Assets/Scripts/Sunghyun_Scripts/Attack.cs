using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Pattern
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _delayTime;
    [SerializeField] private float _RaycastRange;
    [SerializeField] private float _offsetYPosition;
    
    
    private Animator _animator;
    private MonsterBase _monsterBase;
    private Coroutine _attackRoutine;
    private Vector3 _monsterRayPoint;
    private int _attackDamage;
    private bool _isCoolingDown = false;
    private bool _isAttacked = false;
    
    public bool IsAttacking { get;  private set; }
    
    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();

    private void OnDrawGizmos()
    {
        _monsterRayPoint = new Vector3(
            transform.position.x,
            transform.position.y + _offsetYPosition,
            transform.position.z
        );

        Gizmos.color = Color.black;
        Ray ray = new Ray(_monsterRayPoint, transform.forward);
        
        Gizmos.DrawRay(_monsterRayPoint, transform.forward * _RaycastRange);
    }

    // --------------------

    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        _monsterBase = GetComponent<MonsterBase>();
    }

    private void Init()
    {
        _attackDamage = _monsterBase.AttackDamage;
    }
    
    public override void OnAction()
    {
        if (!_isAttacked && !_isCoolingDown) // 아직 공격안했으면
        {
            _isAttacked = true;
            IsAttacking = true;
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        // 애니메이션
        //_animator.SetBool();

        Debug.Log("공격중........");
        yield return new WaitForSeconds(_delayTime); // 애니메이션 중간정도 시간
        Debug.Log("공격완료......");
        
        ShootRay(); // Raycast 쏘고

        _isAttacked = false;
        
        // 공격 쿨타임 구현
        _isCoolingDown = true;
        Debug.Log("쿨타임돌아가는중........");
        yield return new WaitForSeconds(_attackCooldown);
        Debug.Log("쿨타임 끝남........");
        _isCoolingDown = false;

        IsAttacking = false;
        
        _monsterBase.ChangeChasePattern();
    }

    private void ShootRay()
    {
        _monsterRayPoint = new Vector3(
            transform.position.x,
            transform.position.y + _offsetYPosition,
            transform.position.z
        );
        
        Ray ray = new Ray(_monsterRayPoint, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _RaycastRange, _layerMask))
        {
            IDamageable damageable = hit.transform.GetComponent<IDamageable>();
            
            damageable.TakeDamage(_attackDamage);
        }

    }
}
