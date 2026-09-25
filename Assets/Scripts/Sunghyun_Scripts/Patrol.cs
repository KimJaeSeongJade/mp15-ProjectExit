using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Pattern
{
    [SerializeField] private List<WayPoint> _wayPoints;

    private MonsterDetection _detection;
    private MonsterBase _monsterBase;
    private Vector3 _nextPosition;
    private int _currentWayPointIndex = 0;
    private float _moveSpeed;
    private float _distance = float.MaxValue;
    private bool _isReverseCycle = false;
    
    // --------------------

    private void Awake() => CacheComponents();

    private void Start() => Init();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < _wayPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(_wayPoints[i].transform.position, _wayPoints[i + 1].transform.position);
        }
    }

    // --------------------

    private void CacheComponents()
    {
        _monsterBase = GetComponent<MonsterBase>();
        _detection = GetComponentInChildren<MonsterDetection>();
    }

    private void Init()
    {
        _moveSpeed = _monsterBase.MoveSpeed;
        CalculateStartPosition();
    }
    
    public override void OnAction()
    {
        if (_detection.PlayerTransform != null)
        {
            _monsterBase.ChangeChasePattern();
            return;
        }
        
        if (Vector3.Distance(transform.position, _nextPosition) > 0.2f)
        {
            MoveToPosition();
        }
        else
        {
            CalculateNextPosition();
        }
    }
    
    /// <summary>
    /// 가장 가까운 웨이포인트 계산하는 함수
    /// </summary>
    public void CalculateStartPosition()
    {
        for (int i = 0; i < _wayPoints.Count; i++)
        {
            float calculateDistance = 
                Vector3.Distance(transform.position, _wayPoints[i].transform.position);

            if (calculateDistance < _distance)
            {
                _distance = calculateDistance;
                _currentWayPointIndex = i;
                _nextPosition = _wayPoints[_currentWayPointIndex].transform.position;
            }
        }
        _distance = float.MaxValue;
    }

    private void CalculateNextPosition()
    {
        if (!_isReverseCycle) // 정방향 순회
        {
            if (_currentWayPointIndex < _wayPoints.Count -1)
            {
                _currentWayPointIndex++;
                _nextPosition = _wayPoints[_currentWayPointIndex].transform.position;
            }
            else // 현재 위치가 인덱스 맨 끝
            {
                _currentWayPointIndex--;
                _nextPosition = _wayPoints[_currentWayPointIndex].transform.position;
                _isReverseCycle = true;
            }
        }
        else // 역방향 순회
        {
            if (_currentWayPointIndex > 0)
            {
                _currentWayPointIndex--;
                _nextPosition = _wayPoints[_currentWayPointIndex].transform.position;
            }
            else // 현재 위치가 인덱스 맨 처음
            {
                _currentWayPointIndex++;
                _nextPosition = _wayPoints[_currentWayPointIndex].transform.position;
                _isReverseCycle = false;
            }
        }
    }

    /// <summary>
    /// 가장 가까운 웨이포인트로 이동하는 함수
    /// </summary>
    private void MoveToPosition()
    {
        Vector3 dir = _nextPosition - transform.position;
        transform.position = Vector3.MoveTowards(
            transform.position,
            _nextPosition,
            _moveSpeed * Time.deltaTime);
        
     
        transform.rotation = Quaternion.LookRotation(dir, transform.up);
    }
}