using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleA_Manager : Singleton<PuzzleA_Manager>
{
   [SerializeField] private Renderer[] _platforms;
   
   private Renderer _renderer;
   private Coroutine _resetRoutine;
   
   
   
   
   private void Awake()
   {
      SetSingleton();
   }

   private void ResetPlatform()
   {
      for (int i = 0; i < _platforms.Length; i++)
      {
         // _platforms[i].material = ;
      }
      if (_resetRoutine != null)
      {
         StopCoroutine(_resetRoutine);
         _resetRoutine = null;
      }
   }
   
  

  
}
