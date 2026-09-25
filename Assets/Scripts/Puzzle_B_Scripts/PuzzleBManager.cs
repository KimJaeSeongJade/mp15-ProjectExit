using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBManager : PuzzleBase
{
    [SerializeField] private DetectPlatform _detectPlatform; // 타일을 참조
    [SerializeField] private PuzzleBMessage _puzzleBMessage;
    
    private void Update()
    {
        JudgePuzzleCleared();
    }
    
    // 반환형이 없는 메서드입니다.
    private void JudgePuzzleCleared()
    {
        if (!_detectPlatform.CanClearPuzzle())
        {
            return;
        }
        else if (_detectPlatform.CanClearPuzzle())
        {
            IsClear = true;
            Debug.Log("Puzzle B Cleared");
            _puzzleBMessage.gameObject.SetActive(true);
        }
    }

    // bool 타입으로 반환하는 메서드 따로 빼놓았습니다.
    /*public bool JudgePuzzleCleared()
    {
        if (_detectPlatform.CanClearPuzzle())
        {
            return true;
            _puzzleBMessage.gameObject.SetActive(true);
        }
        else
        {
            return false;
        }
    }*/
}
