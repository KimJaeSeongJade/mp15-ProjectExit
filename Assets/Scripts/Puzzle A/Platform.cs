using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Materials Settings")]
    [SerializeField] private Material _baseMat;

    [SerializeField] private Material _platformColor;

    [SerializeField] private PuzzleA_Manager _manager;
    private Renderer _renderer;
    private Coroutine _resetRoutine;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
     
    }

    private void Start()
    {
        _renderer.material = _baseMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !_manager._Rot)
        {
            OnPlatform();
        }
    }

    public void OnPlatform()
    {
       OnColor();

        if (!_manager._playerArray.Contains(this))
        {
            _manager.OnStepPlatform(this);
        }
    }

    public void OnColor()
    {
        _renderer.material = _platformColor;

    }

    public void OffColor()
    {
        _renderer.material = _baseMat;
    }

    public void FixOnColor()
    {
        _renderer.material = _platformColor;
    }
    
}
