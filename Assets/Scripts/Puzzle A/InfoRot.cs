using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRot : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Awake() => CacheComponents();
    private void LateUpdate() => Rotate();

    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Rotate()
    {
        transform.forward = _cameraTransform.forward;
    }
    
    /*[SerializeField] private Transform _target;

    private void Update()
    {
        LookatTarget();
    }

    private void LookatTarget()
    {
        transform.LookAt(_target);
    }*/
}