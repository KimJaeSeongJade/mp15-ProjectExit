using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Material _baseMat;
    [SerializeField] private Material _onStepMat;
    
    private Renderer _renderer;
    private Coroutine _resetRoutine;
  //  private bool _isBaseColor;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        PuzzleA_Manager.Instance.OffColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Platform : 퍼즐A 시작.");  // UI 로 띄워주면 좋겠다.
            PuzzleA_Manager.Instance.OnColor();
        }
    }

   
}
