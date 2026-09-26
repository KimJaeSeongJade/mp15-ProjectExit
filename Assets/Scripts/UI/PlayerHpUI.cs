using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private Image _gauge;
    [SerializeField] private float _maxHp;
    private float _currentHp;

    private void Awake() => Init();
    private void LateUpdate()
    {
        RefreshMonsterHp();
        Damage();
    }
    
    private void RefreshMonsterHp()
    {
        _gauge.fillAmount = _currentHp / _maxHp;
    }

    private void Init()
    {
        _currentHp = _maxHp;
    }
    
    // + 임시 키
    private KeyCode _damageKey = KeyCode.Space;
    private float _damageAmount = 20f;
    private bool _isPressedDamageKey => Input.GetKeyDown(_damageKey); 
    
    private void Damage()
    {
        if(!_isPressedDamageKey)
            return;
        
        _currentHp -= _damageAmount;
    }
}
