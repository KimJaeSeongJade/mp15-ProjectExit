using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Materials Settings")]
    [SerializeField] private Material _baseMat;

    [SerializeField] private Material _platformColor;
    [SerializeField] private float _colorDuration;

    [SerializeField] private PuzzleA_Manager _manager;
    private Renderer _renderer;
    private Coroutine _resetRoutine;
    private bool _isClear;
    
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _isClear = false;
    }

    private void Start()
    {
        _renderer.material = _baseMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isClear)
        {
            OnColor();
        }
    }

    public void OnColor()
    {
        _renderer.material = _platformColor;
        
        // 타임아웃이 돌아가고 있으면 리셋시키는 코드
        if (_resetRoutine != null)  
        {
            StopCoroutine(_resetRoutine);
            _resetRoutine = null;
        }
        _resetRoutine = StartCoroutine(ColorDuration());

        if (!_manager._playerArray.Contains(this))
        {
            _manager.OnStepPlatform(this);
        }
    }

    public void ResetPlatform()
    {
        OffColor();

        if (_resetRoutine != null)
        {
            StopCoroutine(_resetRoutine);
            _resetRoutine = null;
        }
    }

    private void OffColor()
    {
        _renderer.material = _baseMat;
    }

    private IEnumerator ColorDuration()
    {
        yield return new WaitForSeconds(_colorDuration);
        OffColor();
    }

    public void FixOnColor()
    {
        if (_resetRoutine != null)
        {
            StopCoroutine(_resetRoutine);
            _resetRoutine = null;
        }

        _renderer.material = _platformColor;
    }

    public void Clear()
    {
        _isClear = true;
    }
}
