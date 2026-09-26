using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterAnimController : MonoBehaviour
{
    public event Action<bool> OnMove;
    public event Action<bool> OnAttack;
    public event Action<bool> OnIdle;
    
    private Chase _chase;
    private Attack _attack;
    private bool _isMove;
    private bool _isAttack;
    private bool _isIdle;

    private void Awake()
    {
        _chase = GetComponentInParent<Chase>();
        _attack = GetComponentInParent<Attack>();
    }
    
    private void Update()
    {
        StateUpdate();
        
        OnMove?.Invoke(_isMove);
        OnAttack?.Invoke(_isAttack);
        OnIdle?.Invoke(_isIdle);
    }

    private void StateUpdate()
    {
        if (_attack.IsAttacking) // 공격하는중
        {
            _isMove = false;
            _isAttack = true;
            _isIdle = false;
        }
        else if (_chase.IsIdling) // Idle 중
        {
            _isMove = false;
            _isAttack = false;
            _isIdle = true;
        }
        else // 패트롤중
        {
            _isMove = true;
            _isAttack = false;
            _isIdle = false;
        }
    }


    
}