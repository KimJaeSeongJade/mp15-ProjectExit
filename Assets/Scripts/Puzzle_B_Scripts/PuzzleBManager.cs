using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBManager : MonoBehaviour
{
    [SerializeField] private DetectPlatform _detectPlatform; // 타일을 참조
    
    public bool IsClear = false;
    
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

        IsClear = true;
        Debug.Log("Puzzle B Cleared");
    }

    // bool 타입으로 반환하는 메서드 따로 빼놓았습니다.
    /*public bool JudgePuzzleCleared()
    {
        if (!_detectPlatform.isClear)
        {
            return false;
        }

        return true;
    }*/
}
