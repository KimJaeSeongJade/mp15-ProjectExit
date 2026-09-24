using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleA_Manager : Singleton<PuzzleA_Manager>
{
   [SerializeField] private Renderer[] _platforms;
   [SerializeField] private float _timeOut;
   
   private Renderer _renderer;
   private Coroutine _resetRoutine;
   
   [Header("Platform Materials Settings")]
   private Material _baseMat;
   private Material _onStepMat;
   
   
   private void Awake()
   {
      SetSingleton();
   }

   private void ResetPlatform()
   {
      for (int i = 0; i < _platforms.Length; i++)
      {
         _platforms[i].material = _baseMat;
      }
      if (_resetRoutine != null)
      {
         StopCoroutine(_resetRoutine);
         _resetRoutine = null;
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
