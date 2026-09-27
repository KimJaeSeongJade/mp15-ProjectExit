using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    [SerializeField] private List<PuzzleBase> _puzzles = new(3);
    public List<PuzzleBase> Puzzles => _puzzles;
    public event Action<bool> OnClearAllPuzzles;
    public event Action OnClearPuzzle;

    private void Awake() => SetSingleton();

    public void AddPuzzle(PuzzleBase puzzle)
    {
        _puzzles.Add(puzzle);
    }

    public void RemovePuzzle(PuzzleBase puzzle)
    {
        _puzzles.Remove(puzzle);
    }

    public void ClearPuzzle()
    {
        OnClearPuzzle?.Invoke();
        
        CheckClearAllPuzzles();
    }
    
    private void CheckClearAllPuzzles()
    {
        bool isClearAllPuzzles = true;
        
        foreach (PuzzleBase puzzle in _puzzles)
        {
            if(!puzzle.IsClear)
            {
                isClearAllPuzzles = false;
                break;
            }
        }

        OnClearAllPuzzles?.Invoke(isClearAllPuzzles);
    }
}
