using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private Image _gauge;
    
    private PlayerStat _playerStat;

    private void OnEnable() => TryBindPlayer();

    private void Update()
    {
        if (_playerStat == null)
            TryBindPlayer(); 
    }

    private void OnDisable()
    {
        if (_playerStat != null)
            _playerStat.OnHealthChanged -= RefreshGauge;
    }

    private void TryBindPlayer()
    {
        _playerStat = FindObjectOfType<PlayerStat>();
        if (_playerStat == null) return;

        _playerStat.OnHealthChanged += RefreshGauge;
        RefreshGauge(_playerStat.PlayerHealth, _playerStat.MaxHealth); 
    }

    private void RefreshGauge(int current, int max)
    {
        _gauge.fillAmount = (float)current / max;
    }
}
