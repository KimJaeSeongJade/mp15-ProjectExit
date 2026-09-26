using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSm : MonoBehaviour, IDamageable, IInteractor
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _muzzlePoint;
    private PlayerMovement _movement;
    private PlayerStat _stat;
    [field: SerializeField] public Transform GrapPoint;
    
    private float _rayDistance = 2f;
    
    private IInteractable _item;
    private IInteractor _targetIneractable;
    
    public GameObject GameObject {get => gameObject;}
    
    public bool _isDead => _stat.PlayerHealth <= 0;
    public Rigidbody GetPlayerRigidbody => _movement._rigidbody;
    
    private Transform _cameraTransform;
    
    private void Awake() => CacheComponents();
    private void OnEnable() => BindGameFlowEvents();
    private void FixedUpdate() => _movement.Move();
    private void Update()
    {
        if(GameManager.Instance.IsGameClear) return;
        if(Time.timeScale == 0) return;
        
        DetectItem();
        GetInteract();
        _movement.Rotate();
    }

    private void LateUpdate() => SetCameraTransform();
    private void OnDisable() => UnbindGameFlowEvents();
    
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
    
    public void TryInteract()
    {
        if (_item != null)
        {
            _item.Interact(this);
            Debug.Log($"TryInteract: {name} interacted with {_item}");
        }
    }
    
    private void DetectItem()
    {
        Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.red);
            _item = hit.collider.GetComponent<IInteractable>();
            Debug.Log($"DetectItem: {name} interacted with {_item}");
        }
        else
        {
            _item = null;
        }
    }
    
    private void GetInteract()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }
    
    private void CacheComponents()
    {
        _movement = GetComponent<PlayerMovement>();
        _stat = GetComponent<PlayerStat>();
        _cameraTransform = Camera.main.transform;
    }

    private void SetCameraTransform()
    {
        if (GameManager.Instance.IsGameClear) return;
        
        _cameraTransform.SetPositionAndRotation(_cameraPivot.position, _cameraPivot.rotation);
    }

    private void BindGameFlowEvents()
    {
        GameManager.Instance.OnGameClear += OnGameClear;
    }

    private void UnbindGameFlowEvents()
    {
        GameManager.Instance.OnGameClear -= OnGameClear;
    }

    private void OnGameClear()
    {
        GetPlayerRigidbody.useGravity = true;
        Destroy(GetComponent<Collider>());
    }
}
