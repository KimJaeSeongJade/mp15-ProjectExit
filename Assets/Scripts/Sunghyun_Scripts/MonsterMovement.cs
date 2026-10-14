using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private MonsterBase _monsterBase;
    private float _moveSpeed;
    private Vector3 _targetPosition;

    // --------------------
    
    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // --------------------
    
    private void CacheComponents()
    {
        _monsterBase = GetComponent<MonsterBase>();
    }

    private void Init()
    {
        _moveSpeed = _monsterBase.MoveSpeed;
        _targetPosition = new();
    }
    
    
    public void Move(Vector3 targetPosition)
    {
        _targetPosition = new Vector3(targetPosition.x, 0f, targetPosition.z);
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            _targetPosition,
            _moveSpeed * Time.deltaTime
            );
        
        transform.LookAt(_targetPosition);
    }
}
