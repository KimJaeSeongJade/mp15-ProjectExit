using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Pattern
{
    private int _attackDamage;
    private Animator _animator;
    private bool _IsAttacked;
    
    public override void OnAction()
    {
        if (!_IsAttacked) // 아직 공격안했으면
        {
            // 애니메이션 출력
        }
        
        
        
    }
}
