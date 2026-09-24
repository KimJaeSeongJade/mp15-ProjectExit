using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PuzzleA_Manager : MonoBehaviour
{
   [SerializeField] private List<Platform> _clearArray;
   [SerializeField] private Material _base;

   public List<Platform> _playerArray = new(6);

   private bool IsClear;
   private int clearCount;
   
   private void Awake()
   {
      clearCount = 0;
      IsClear = false;
   }

   public void OnStepPlatform(Platform platform)
   {
      _playerArray.Add(platform);
      
      bool isClear = true;
      
      for (int i = 0; i < _playerArray.Count; i++)
      {
         if (_playerArray[i] != _clearArray[i])
         {
            isClear = false;
            break;
         }
      }
      
      if (!isClear)
      {
         ResetPlatforms();
         _playerArray.Clear();
         IsClear = false;
      }

      if (isClear && _playerArray.Count == _clearArray.Count)
      {
         foreach (Platform p in _playerArray)
         {
            p.FixOnColor();
            p.Clear();
         }

         IsClear = true;
      }
   }

   public void ResetPlatforms()
   {
      foreach (Platform platform in _playerArray)
      {
         platform.ResetPlatform();
      }
   }
}
