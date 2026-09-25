using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PuzzleA_Manager : MonoBehaviour
{
   [SerializeField] private List<Platform> _clearArray;
   [SerializeField] private Material _base;
   [SerializeField] private TextMeshProUGUI _textInfo;
   
   public List<Platform> _playerArray = new(6);

   public bool IsClear = false;
   private int clearCount;
   
   private void Awake()
   {
      clearCount = 0;
      IsClear = false;
      _textInfo.text = "=RAINBOW=";
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
         _textInfo.text = "FAIL.";
         StartCoroutine(Text());
         ResetPlatforms();
         _playerArray.Clear();
         IsClear = false;
      }

      if (isClear && _playerArray.Count == _clearArray.Count)
      {
         foreach (Platform p in _playerArray)
         {
            _textInfo.text = "CLEAR!";
            p.FixOnColor();
         }

         IsClear = true;
      }
   }

   private IEnumerator Text()
   {
      yield return new WaitForSeconds(2f);
      _textInfo.text = "=RAINBOW=";
   }


   public void ResetPlatforms()
   {
      foreach (Platform platform in _playerArray)
      {
         platform.OffColor();
      }
   }
}
