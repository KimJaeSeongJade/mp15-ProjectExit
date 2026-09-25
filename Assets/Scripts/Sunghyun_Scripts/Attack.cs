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
    private WaitForSeconds _waitForSeconds;
    private Vector3 _monsterRayPoint;
    private int _attackDamage;
    private bool _isCoolingDown;
    
    public bool IsAttacked;
    
    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();
        
    // --------------------

    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        _monsterBase = GetComponent<MonsterBase>();
    }

    private void Init()
    {
        _attackDamage = _monsterBase.AttackDamage;
        _waitForSeconds = new WaitForSeconds(_delayTime);
    }
    
    public override void OnAction()
    {
        if (!IsAttacked && !_isCoolingDown) // 아직 공격안했으면
        {
            IsAttacked = true;
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        // 애니메이션
        //_animator.SetBool();

        yield return _waitForSeconds; // 애니메이션 중간정도 시간

        ShootRay(); // Raycast 쏘고

        IsAttacked = false;
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
