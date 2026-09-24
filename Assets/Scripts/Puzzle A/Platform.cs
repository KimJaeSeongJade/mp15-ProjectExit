using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Materials Settings")]
    [SerializeField] private Material _baseMat;
    [SerializeField] private Material _onStepMat;
    [SerializeField] private Renderer[] _clearArray;
    [SerializeField] private float _timeOut;
    
    private Renderer _renderer;
    private Coroutine _resetRoutine;
    private Renderer[] _playerArray = new Renderer[6];
    
    
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        OffColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Platform : 퍼즐A 시작.");  // UI 로 띄워주면 좋겠다.
            OnColor();
        }
    }
    public void OnColor()
    {
        _renderer.material = _onStepMat;
        
        // 타임아웃이 돌아가고 있으면 리셋시키는 코드
        if (_resetRoutine != null)  
        {
            StopCoroutine(_resetRoutine);
            _resetRoutine = null;
        }
        _resetRoutine = StartCoroutine(Timeout());
    }

    public void OffColor()
    {
        _renderer.material = _baseMat;
    }
    private IEnumerator Timeout()
    {
        yield return new WaitForSeconds(_timeOut);
        OffColor();
    }
}
