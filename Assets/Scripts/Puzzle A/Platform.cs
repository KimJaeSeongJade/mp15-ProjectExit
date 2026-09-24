using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _timeOut;
    
    [Header("Platform Materials Settings")]
    [SerializeField] private Material _baseMat;
    [SerializeField] private Material _onStepMat;
    
    private Renderer _renderer;
    private Coroutine _resetRoutine;
    private bool _isBaseColor => _baseMat;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        OffColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{other.name} (이)가 버튼 위에 올라왔습니다.");
            OnColor();
        }
    }

    public void OnColor()
    {
        Debug.Log("컬러 변경요청");
        _renderer.material = _onStepMat;

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
        Debug.Log("타임아웃 시작");
        yield return new WaitForSeconds(_timeOut);
        OffColor();
    }


}
