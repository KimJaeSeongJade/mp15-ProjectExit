using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; // 속도
    [SerializeField] private GameObject _cameraTarget; // 카메라 시점 중심
    [SerializeField] private Transform _playerCam; // 메인카메라 위치 참조
    [SerializeField] private float _mouseSensitivity; // 마우스 민감도
    [SerializeField] private float _minPitch; // 마우스 최하 각도
    [SerializeField] private float _maxPitch; // 마우스 최대 각도
    
    private Camera _camera; // 메인카메라 참조
    private float _pitch;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        
    }

    private void Update()
    {
        PlayerMovement();
        SetCameraSight();
        
    }
    
    private Vector3 ReadMouseInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        
        return new Vector3(x, -y, 0);
    }

    private void SetCameraSight()
    {
        _camera.transform.position = _playerCam.position;
        _camera.transform.LookAt(_cameraTarget.transform);
        
        Vector3 _mouseInput = ReadMouseInput() *  _mouseSensitivity;

        transform.Rotate(0, _mouseInput.x, 0, Space.Self);
        _pitch =  Mathf.Clamp(_pitch +  _mouseInput.y, -_minPitch, _maxPitch);
        _cameraTarget.transform.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

    private void PlayerMovement()
    {
        Vector3 moveInput = ReadMoveInput();
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.z;

        Vector3 playerVelocity = new Vector3(
            direction.x * _moveSpeed,
            _rb.velocity.y,
            direction.z * _moveSpeed);
        _rb.velocity = playerVelocity;
    }

    private Vector3 ReadMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        return new Vector3(x, 0, z).normalized;
    }
}
