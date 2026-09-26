using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStat : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; set; } = 100;
    [field: SerializeField] public float MoveSpeed { get; set; } = 5f;

    [field: SerializeField] public float InteractRange { get; set; } = 10f;
    
    // + 추가
    private int _playerHealth;
    public int PlayerHealth
    {
        get => _playerHealth;
        set
        {
            _playerHealth = Mathf.Clamp(value, 0, MaxHealth);
            OnHealthChanged?.Invoke(_playerHealth, MaxHealth);
        }
    }

    public event Action<int, int> OnHealthChanged;

    private void Awake()
    {
        PlayerHealth = MaxHealth; // 초기화하면서 최초 이벤트도 한 번 발생시킴
    }
}
