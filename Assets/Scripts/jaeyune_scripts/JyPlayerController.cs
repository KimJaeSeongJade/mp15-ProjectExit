using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JyPlayerController : MonoBehaviour, IJyInteractor
{
    // Rigidbody를 통한 velocity.
    [field: SerializeField] public float _playerMoveSpeed;
    private Rigidbody _rigidbody;
    
    
    [SerializeField] private Transform _muzzlePoint;
    [field: SerializeField] public Transform GrapPoint;
    
    
    private float _rayDistance = 2f;
    private IJyInteractable _item;

    public Rigidbody GetPlayerRigidbody => _rigidbody;
    
    private void Awake() => Init();
    private void Update()
    {
        DetectItem();  
        GetInteract();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private Vector3 ReadMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        return new Vector3(x, 0, z).normalized;
    }

    private void Move()
    {
        Vector3 input = ReadMoveInput();
        
        Vector3 direction = transform.right * input.x + transform.forward * input.z;
        Vector3 vel = new Vector3(direction.x * _playerMoveSpeed, _rigidbody.velocity.y,
                                       direction.z * _playerMoveSpeed);
        
        _rigidbody.velocity = vel;
    }
    
    
    public GameObject GmOjt { get => gameObject; }

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
            _item = hit.collider.GetComponent<IJyInteractable>();
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

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
