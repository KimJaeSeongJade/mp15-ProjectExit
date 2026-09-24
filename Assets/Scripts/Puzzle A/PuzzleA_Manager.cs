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
   private int clear;
   
   private void Awake()
   {
      SetSingleton();
      clear = 0;
   }

   private void Update()
   {
      Test();
   }


   public void ResetPlatform()
   {
      Debug.Log($"PuzzleA_Manager : 오답입니다.");
      for (int i = 0; i < _playerArray.Count; i++)
      {
          _playerArray[i].material = _base;
      }
      if (_resetRoutine != null)
      {
         StopCoroutine(_resetRoutine);
         _resetRoutine = null;
      }
      _playerArray.Clear();
      clear = 0;
   }
   
   public void IsInOrder()
   { 
      for (int i = 0; i < _playerArray.Count; i++)
      {
         if (_playerArray[i] != _clearArray[i])
         {
            // 추가 구현 : 깜빡이다가 리셋 되도록?
            ResetPlatform();
            clear = 0;
            break;
         }
         else if (_playerArray[i] == _clearArray[i])
         {
            ++clear;
            Debug.Log($"PuzzleA_Mnager : 정답 갯수 {clear}");
         }
      }

      if (clear >= 6)
      {
         Debug.Log($"PuzzleA_Manager : 퍼즐A 클리어.");
      }
   }
   
   private void Test()
   {
      if (Input.GetKey(KeyCode.Alpha1))
      {
         Debug.Log($"플레이어 리스트 {_playerArray[0].name}");
         Debug.Log($"정답 리스트 {_clearArray[0].name}{_clearArray[1].name}{_clearArray[2].name}{_clearArray[3].name}{_clearArray[4].name}{_clearArray[5].name}");
      }
   }
}
