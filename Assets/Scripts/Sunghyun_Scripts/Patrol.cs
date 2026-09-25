using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Pattern
{
    [SerializeField] private List<WayPoint> _wayPoints;

    private MonsterBase _monsterBase;
    private int _currentWayPoint = 0;
    private float _moveSpeed;
    private float _distance = float.MaxValue;
    private Vector3 _startPosition;
    
    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
    }

    // --------------------

    private void CacheComponents()
    {
        _monsterBase = GetComponent<MonsterBase>();
    }

    private void Init()
    {
        _moveSpeed = _monsterBase.MoveSpeed;
        CalculateStartPosition();
    }
    
    public override void OnAction()
    {
        if (Vector3.Distance(transform.position, _startPosition) > 0.1f)
        {
            CalculateStartPosition();
            
            MoveToStartPosition();
        }
    }
    
    /// <summary>
    /// 가장 가까운 웨이포인트 계산하는 함수
    /// </summary>
    private void CalculateStartPosition()
    {
        for (int i = 0; i < _wayPoints.Count; i++)
        {
            float calculateDistance = 
                Vector3.Distance(transform.position, _wayPoints[i].transform.position);

            if (calculateDistance < _distance)
            {
                _distance = calculateDistance;
                _startPosition = _wayPoints[i].transform.position;
            }
        }
        Debug.Log(_startPosition);
    }

    /// <summary>
    /// 가장 가까운 웨이포인트로 이동하는 함수
    /// </summary>
    private void MoveToStartPosition()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _startPosition,
            _moveSpeed * Time.deltaTime);
    }
    
    //private void 
}
