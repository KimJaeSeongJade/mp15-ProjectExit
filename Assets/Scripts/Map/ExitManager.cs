using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] private Transform _exitSpawnPoint;
    [SerializeField] private GameObject _exit;

    private PuzzleA_Manager _puzzleAManager;
    private PuzzleBManager _puzzleBManager;
    private PuzzleCManager _puzzleCManager;

    private bool _puzzleAClear => _puzzleAManager.IsClear;
    private bool _puzzleBClear => _puzzleBManager.IsClear;
    private bool _puzzleCClear => _puzzleCManager.IsClear;
    
    private bool _allClear => _puzzleAClear &&  _puzzleBClear && _puzzleCClear;
    
    private void Awake() => CacheComponents();

    private void CacheComponents()
    {
        _puzzleAManager = GetComponent<PuzzleA_Manager>();
        _puzzleBManager = GetComponent<PuzzleBManager>();
        _puzzleCManager = GetComponent<PuzzleCManager>();
    }
    
    private void PuzzleClear()
    {
        if (!_allClear) return;
        
        Instantiate(_exit, _exitSpawnPoint.position, Quaternion.identity);
    }

    private void ExitHole()
    {
        
    }
}