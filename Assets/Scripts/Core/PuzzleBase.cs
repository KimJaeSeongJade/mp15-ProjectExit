using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleBase : MonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }

    private bool _isClear = false;
    public bool IsClear
    {
        get => _isClear;
        set
        {
            _isClear = value;
            if(_isClear) GameManager.Instance.OnPuzzleCleared?.Invoke();
        }
    }
    
    public event Action OnPuzzleCleared;
}
