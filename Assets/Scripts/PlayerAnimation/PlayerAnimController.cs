using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimController : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnDead;

    private Vector2 _prevMovement;
    private PlayerControllerSm _playerController;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerControllerSm>();
    }
    
    private bool _isDead => _playerController._isDead;
    
    private void Update()
    {
        if(Time.timeScale == 0) return;
        
        SetMove();
        SetDead();
    }

    private void SetMove()
    {
        Vector2 movement = GetMovement();
        if (_prevMovement == movement) return;
        
        OnMove?.Invoke(movement);
        _prevMovement = movement;
    }

    private Vector2 GetMovement()
    {
        return new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
    }
    
    private void SetDead()
    {
        bool dead = GetDead();
        if (!dead) return;
        
        OnDead?.Invoke(dead);
    }

    private bool GetDead()
    {
        if (_isDead)
        {
            return true;
        }
        return false;
    }
}
