using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _mouseSensitivity = 5f;
    [SerializeField] private float _minPitch = -60f;
    [SerializeField] private float _maxPitch = 60f;

    private float _pitch;

    public Rigidbody _rigidbody;
    private PlayerStat _playerStat;
    private PlayerController _controller;
    // dsd
    private float _moveSpeed => _playerStat.MoveSpeed;

    private void Awake() => CacheComponents();

    public void Rotate()
    {
        Vector3 input = ReadRotateInput() * _mouseSensitivity;

        transform.Rotate(0, input.y, 0, Space.Self);
        _pitch = Mathf.Clamp(_pitch + input.x, _minPitch, _maxPitch);
        _cameraPivot.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }
    
    private Vector3 ReadRotateInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector3(-y, x, 0);
    }
    public void Move()
    {
        Vector3 input = ReadMoveInput();
        
        Vector3 direction = transform.right * input.x + transform.forward * input.z;

        Vector3 newVelocity = new Vector3(
            direction.x * _moveSpeed,
            _rigidbody.velocity.y,
            direction.z * _moveSpeed);
        
        _rigidbody.velocity = newVelocity;
    }

    private Vector3 ReadMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        return new Vector3(x, 0, z).normalized;
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerStat = GetComponent<PlayerStat>();
    }
}
