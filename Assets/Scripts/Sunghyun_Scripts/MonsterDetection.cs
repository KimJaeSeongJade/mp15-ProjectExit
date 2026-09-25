using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetection : MonoBehaviour
{
    [SerializeField] private float _DetectAngle;
    [SerializeField] private float _offsetYPosition;
    [SerializeField] private LayerMask _layerMask;
    
    private SphereCollider _collider;
    private Transform _transformInTrigger;
    private Transform _monsterPostion;
    private Vector3 _monsterRayPoint;
    private Vector3 _targetRayPoint;
    private Vector3 _rayDirection;
    private float _detectRange;
    
    
    public Transform PlayerTransform { get; private set; }

    private bool IsInPlayerLayer(GameObject target)
    {
        return (_layerMask.value & (1 << target.layer)) != 0;
    }

    // --------------------
    
    private void Awake() => CacheComponents();

    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsInPlayerLayer(other.gameObject))
        {
            _transformInTrigger = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsInPlayerLayer(other.gameObject))
        {
            _transformInTrigger = null;
        }
    }

    private void Update()
    {
        DetectingPlayer();
    }
    
    // --------------------
    
    private void CacheComponents()
    {
        _collider = GetComponent<SphereCollider>();
        _monsterPostion = transform.parent;
    }

    private void Init()
    {
        _detectRange = _collider.radius;
    }

    private void DetectingPlayer()
    {
        if (_transformInTrigger == null)
        {
            PlayerTransform = null;
            return;
        }
        
        if(IsPlayerInDetectRange(_transformInTrigger) && IsRaycastReached(_transformInTrigger))
        {
            PlayerTransform = _transformInTrigger;
        }
    }
    
    /// <summary>
    /// 2차필터 : 벡터내적 활용한 부채꼴 감지
    /// </summary>
    private bool IsPlayerInDetectRange(Transform TriggerTransform)
    {
        Vector3 vectorToTarget = (TriggerTransform.position - transform.position).normalized;

        float targetDot = Vector3.Dot(transform.forward, vectorToTarget); // 타겟과의 벡터내적값 연산

        float threshold = Mathf.Cos(_DetectAngle * 0.5f * Mathf.Deg2Rad); // 기준 벡터내적값
        
        
        return (targetDot >= threshold);
    }

    /// <summary>
    /// 3차필터 : Raycast
    /// </summary>
    private bool IsRaycastReached(Transform TriggerTransform)
    {
        _monsterRayPoint = new Vector3(
            transform.position.x,
            transform.position.y + _offsetYPosition,
            transform.position.z
        );

        _targetRayPoint = new Vector3(
            TriggerTransform.position.x,
            TriggerTransform.position.y + _offsetYPosition,
            TriggerTransform.position.z
        );

        _rayDirection = (_targetRayPoint - _monsterRayPoint).normalized;
        
        Ray ray = new Ray(_monsterRayPoint, _rayDirection);
        RaycastHit hit; 
        
        if(Physics.Raycast(ray, out hit, _detectRange))
        {
            if (IsInPlayerLayer(hit.transform.gameObject))
            {
                return true;
            }
        }
        return false;
    }
    
    
    // 에디터 시각화
    // --------------------
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_detectRange);
        
        // 부채꼴
        if(_transformInTrigger == null) return;
        if (!IsPlayerInDetectRange(_transformInTrigger)) return;
        
        Vector3 leftDir = Quaternion.Euler(0f,-_DetectAngle / 2 , 0f) * _monsterPostion.forward;
        Vector3 rightDir = Quaternion.Euler(0f,_DetectAngle / 2 , 0f) * _monsterPostion.forward;
        
        Gizmos.DrawRay(transform.position, leftDir * _detectRange);
        Gizmos.DrawRay(transform.position, rightDir * _detectRange);
        
        // 레이캐스트
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_monsterRayPoint, _rayDirection * _detectRange);
    }
}