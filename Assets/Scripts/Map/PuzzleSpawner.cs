using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] private Transform PlayerSpawnPoint;
    [SerializeField] private Transform MonsterSpawnPoint;
    [SerializeField] private Transform _puzzleASpawnPoint;
    [SerializeField] private Transform _puzzleBSpawnPoint;
    [SerializeField] private Transform _puzzleCSpawnPoint;
    [SerializeField] private Transform _exitHolePoint;
    
    [SerializeField] private GameObject _player;
    // [SerializeField] private GameObject _monster;
    
    [SerializeField] private GameObject _puzzleA;
    [SerializeField] private GameObject _puzzleB;
    [SerializeField] private GameObject _puzzleC;
    [SerializeField] private GameObject _exitHole;


    private GameObject _exitHoleInstance;
    private List<PuzzleBase> _puzzles = GameManager.Instance.Puzzles;

    private void OnEnable() => BindGameFlowEvents();
    private void Start() => Spawn();
    private void OnDisable() => UnbindGameFlowEvents();

    private void Spawn()
    {
        Instantiate(_player, PlayerSpawnPoint.position, Quaternion.identity);
        // Instantiate(_monster, MonsterSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleA, _puzzleASpawnPoint.position, Quaternion.identity); 
        Instantiate(_puzzleB, _puzzleBSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleC, _puzzleCSpawnPoint.position, Quaternion.identity);
        _exitHoleInstance = Instantiate(_exitHole, _exitHolePoint.position, Quaternion.identity);
    }

    private void BindGameFlowEvents()
    {
        GameManager.Instance.OnPuzzleCleared += CheckClearAllPuzzles;   
    }

    private void UnbindGameFlowEvents()
    {
        GameManager.Instance.OnPuzzleCleared -= CheckClearAllPuzzles;
    }

    private void CheckClearAllPuzzles()
    {
        bool isClearAllPuzzles = true;
        
        foreach (PuzzleBase puzzle in _puzzles)
        {
            if(!puzzle.IsClear) isClearAllPuzzles = false;
            break;
        }

        if (!isClearAllPuzzles) return;
        
        _exitHoleInstance.gameObject.SetActive(true);
    }
}
