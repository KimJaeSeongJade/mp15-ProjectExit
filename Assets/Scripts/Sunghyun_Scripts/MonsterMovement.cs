using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private MonsterBase _monsterBase;
    private float _moveSpeed;

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
    }
    
    
    public void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            _moveSpeed * Time.deltaTime
            );
        
        transform.LookAt(targetPosition);
    }
}
