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
    
    private Renderer _renderer;
    private Coroutine _resetRoutine;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        OffColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnColor();
            
            PuzzleA_Manager.Instance._playerArray.Add(_renderer);
            StartCoroutine(Campare());
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
    }

    private void OffColor()
    {
        _renderer.material = _baseMat;
    }

    private IEnumerator Campare()
    {
        yield return new WaitForSeconds(1f);
        PuzzleA_Manager.Instance.IsInOrder();
    }
    
    private IEnumerator ColorDuration()
    {
        // 추가구현 : 제한시간이 가까워오면 깜빡이기
        yield return new WaitForSeconds(_colorDuration);
        Debug.Log("시간 초과입니다.");
        PuzzleA_Manager.Instance.ResetPlatform();
    }
    
}
