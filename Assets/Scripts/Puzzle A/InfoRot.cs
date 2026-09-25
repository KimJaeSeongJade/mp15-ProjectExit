using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRot : MonoBehaviour
{

    private Transform _cam;

    private void Start()
    {
        Get();
    }

    void Update()
    {
        Rot();
    }

    private void Get()
    {
        _cam = Camera.main.transform;
    }

    private void Rot()
    {
        transform.forward = _cam.forward;
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