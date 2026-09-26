using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimHandler : MonoBehaviour
{
    [SerializeField] private string _monsterMove;
    [SerializeField] private string _monsterAttack;
    [SerializeField] private string _monsterIdle;

    private MonsterAnimController _controller;
    private Animator _animator;
    

    private void Awake() => CacheComponents();

    private void OnEnable() => BindPlayerEvents();

    private void OnDisable() => UnbindPlayerEvents();
    
    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<MonsterAnimController>();
    }

    private void BindPlayerEvents()
    {
        _controller.OnMove += SetMoveAnim;
        _controller.OnAttack += SetattackAnim;
        _controller.OnIdle += SetIdleAnim;
    }

    private void UnbindPlayerEvents()
    {
        _controller.OnMove -= SetMoveAnim;
        _controller.OnAttack -= SetattackAnim;
        _controller.OnIdle -= SetIdleAnim;
    }

    private void SetMoveAnim(bool isMove)
    {
        _animator.SetBool(_monsterMove, isMove);
    }

    private void SetattackAnim(bool isAttack)
    {
        _animator.SetBool(_monsterAttack, isAttack);
    }
    
    private void SetIdleAnim(bool isIdle)
    {
        _animator.SetBool(_monsterIdle, isIdle);
    }
}