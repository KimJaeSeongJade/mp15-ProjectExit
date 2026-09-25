using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRot : MonoBehaviour
{

    private Transform _cam;

    private void Awake() => Get();
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
}
