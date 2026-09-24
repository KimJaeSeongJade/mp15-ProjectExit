using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PuzzleA_Manager : Singleton<PuzzleA_Manager>
{
   [SerializeField] private List<Renderer> _clearArray;
   [SerializeField] private Material _base;

   public List<Renderer> _playerArray = new List<Renderer>(6);
   
   private Renderer _renderer;
   private Coroutine _resetRoutine;
   private bool IsClear;
   
   private int clearCount;
   
   private void Awake()
   {
      SetSingleton();
      clearCount = 0;
      IsClear = false;
   }
   
   public void ResetPlatform()
   {
      if (_resetRoutine != null)
      {
         StopCoroutine(_resetRoutine);
         _resetRoutine = null;
      }
      
      for (int i = 0; i < _playerArray.Count; i++)
      {
          _playerArray[i].material = _base;
      }
      
      _playerArray.Clear();
      clearCount = 0;
   }
   
   public void IsInOrder() 
   { 
      for (int i = 0; i < _playerArray.Count; i++)
      {
         if (_playerArray[i] != _clearArray[i])
         {
            Debug.Log("오답입니다.");
            // 추가 구현 : 깜빡이다가 리셋 되도록?
            ResetPlatform();
            clearCount = 0;
            break;
         }
         else if (_playerArray[i] == _clearArray[i])
         {
            clearCount++;
            Debug.Log($"PuzzleA_Mnager : 정답 갯수 {clearCount}");
         }
      }

      if (clearCount >= 21)
      {
         Debug.Log($"PuzzleA_Manager : 퍼즐A 클리어.");
         clearCount = 0;
         IsClear = true;
      }
   }
   

}
