using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBMessage : MonoBehaviour
{
    private Transform _cameraTransform; // 메인카메라 참조

    private void Awake() => CacheComponents();
    private void Start() => Init();
    private void Update() => SetRotation();

    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Init()
    {
        transform.gameObject.SetActive(false);
    }

    private void SetRotation()
    {
        transform.forward = _cameraTransform.forward;
    }
}
