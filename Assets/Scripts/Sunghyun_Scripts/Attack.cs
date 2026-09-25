using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Pattern
{
    private int _attackDamage;
    private Animator _animator;
    
    public bool IsAttacked;
    
    // --------------------

    private void Awake() => CacheComponents();
        
    // --------------------

    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
    }
    
    public override void OnAction()
    {
        if (!IsAttacked) // 아직 공격안했으면
        {
            // 애니메이션 출력
            // _animator.SetBool();
            
            // 일정시간 후에(애니메이션 동작 중간쯤 ) 레이캐스트 쏘고
            // 레이캐스트 맞았으면 
            // 맞은애 IDamageable 가져오고
            // IDamageable 통해서 TakeDamage(attackDamage 만큼)
        }
    }
}
