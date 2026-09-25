using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Pattern
{
    [SerializeField] private float _returnDelay;
    
    private bool _remainPositon;
    private Vector3 _lastPosition;
    private Transform _playerTransform;
    private MonsterBase _monsterBase;
    private MonsterDetection _detection;
    private MonsterMovement _monsterMovement;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _idleRoutine;
    
    // --------------------
    
    private void Awake() => CacheComponents();

    private void Start() => Init();
    
    // --------------------
    
    private void CacheComponents()
    {
        _monsterBase = GetComponent<MonsterBase>();
        _detection = GetComponentInChildren<MonsterDetection>();
        _monsterMovement = GetComponent<MonsterMovement>();
    }

    private void Init()
    {
        _waitForSeconds = new WaitForSeconds(_returnDelay);
    }
        
    public override void OnAction()
    {
        _playerTransform = _detection.PlayerTransform; // 3차필터까지 다 ok된 Player
        
        if (_remainPositon) // 플레이어 감지가 끊기고 마지막위치로 이동할때
        {
            if (_playerTransform != null)
            {
                if (_idleRoutine != null)
                {
                    StopCoroutine(_idleRoutine);
                    _idleRoutine = null;
                }   
            }
            else
            {
                MoveRemainPosition();

                if (Vector3.Distance(transform.position, _lastPosition) < 0.1f)
                {
                    _remainPositon = false;
                    _idleRoutine = StartCoroutine(_IdleBeforePatrol());
                }
            }
        }

        if (_playerTransform != null) // 3차 필터까지 ok된 Player 감지상태
        {
            if (_idleRoutine != null)
            {
                StopCoroutine(_idleRoutine);
                _idleRoutine = null;
            }   

            _lastPosition = _playerTransform.position; // Debug. 이거 이래도 되나...?
            
            // 공격
            if (Vector3.Distance(transform.position, _playerTransform.position) < 0.1f)
            {
                _monsterBase.ChangeAttackPattern();
                
                return;
            }
            MoveMonster(_playerTransform.position);
        }
        else // 3차 필터 ok 된 Player 없음
        {
            _remainPositon = true;
        }
    }

    /// <summary>
    /// 플레이어 추적함수
    /// </summary>
    private void MoveMonster(Vector3 position)
    {
        _monsterMovement.Move(position);
    }
    
    /// <summary>
    /// 플레이어가 부채꼴 영역 밖으로 벗어나
    /// 플레이어 마지막 위치로 이동하는 함수
    /// </summary>
    private void MoveRemainPosition()
    {
        _monsterMovement.Move(_lastPosition);
    }

    private IEnumerator _IdleBeforePatrol()
    {
        yield return _waitForSeconds;
        _monsterBase.ChangePatrolPattern();
    }
}