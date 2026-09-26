using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimHandler : MonoBehaviour
{
    [SerializeField] private string _moveXpram;
    [SerializeField] private string _moveZpram;
    [SerializeField] private string _isDead;

    private int _moveX = 0;
    private int _moveZ = 0;
    private bool _playerDead;

    private PlayerAnimController _controller;
    private Animator _animator;
    

    private void Awake()
    {
        Init();
        CacheComponents();
    }

    private void OnEnable() => BindPlayerEvents();

    private void OnDisable() => UnbindPlayerEvents();

    private void Init()
    {
        _moveX = Animator.StringToHash(_moveXpram);
        _moveZ = Animator.StringToHash(_moveZpram);
    }
    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerAnimController>();
    }

    private void BindPlayerEvents()
    {
        _controller.OnMove += SetMoveAnim;
        _controller.OnDead += SetDeadAnim;
    }

    private void UnbindPlayerEvents()
    {
        _controller.OnMove -= SetMoveAnim;
        _controller.OnDead -= SetDeadAnim;
    }

    private void SetMoveAnim(Vector2 movement)
    {
        _animator.SetFloat(_moveX, movement.x);
        _animator.SetFloat(_moveZ, movement.y);
    }

    private void SetDeadAnim(bool isDead)
    {
        _animator.SetBool(_isDead, isDead);
    }
}
