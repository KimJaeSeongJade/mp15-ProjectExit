using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBMessage : MonoBehaviour
{
    [SerializeField] private Transform _playerCam; // 메인카메라 참조
    private void Awake() => Init();

    private void Update() => SetRotation();
    
    private void Init()
    {
        transform.gameObject.SetActive(false);
    }

    private void SetRotation()
    {
        transform.LookAt(_playerCam);
    }
}
