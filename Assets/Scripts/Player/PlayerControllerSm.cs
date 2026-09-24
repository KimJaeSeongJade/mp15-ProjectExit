using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSm : MonoBehaviour, IDamageable
{
    private PlayerMovement _movement;
    private PlayerStat _stat;

    private IInteractable _targetIneractable;
    public bool _isDead => _stat.PlayerHealth <= 0;
    
    private void Awake() => CacheComponents();
    private void FixedUpdate() => _movement.Move();
    private void Update()
    {
        _movement.Rotate();
    }

    public void TakeDamage(int damage)
    {
        _stat.PlayerHealth -= damage;
        Debug.Log(_stat.PlayerHealth);
        if (_isDead) Die();
    }
    
    public void Die()
    {
        // 게임오버 씬
    }
    
    private void CacheComponents()
    {
        _movement = GetComponent<PlayerMovement>();
        _stat = GetComponent<PlayerStat>();
    }
}
