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
    [SerializeField] private GameObject _monster;
    
    [SerializeField] private GameObject _puzzleA;
    [SerializeField] private GameObject _puzzleB;
    [SerializeField] private GameObject _puzzleC;
    [SerializeField] private GameObject _exitHole;


    private GameObject _exitHoleInstance;
    private List<PuzzleBase> _puzzles => PuzzleManager.Instance.Puzzles;

    private void OnEnable() => BindGameFlowEvents();

    private void Start()
    {
        Spawn();
        //GameManager.Instance.StartGame();
    }

    private void OnDisable() => UnbindGameFlowEvents();

    private void Spawn()
    {
        PuzzleManager.Instance.Puzzles.Clear();
        
        Instantiate(_player, PlayerSpawnPoint.position, Quaternion.identity);
        Instantiate(_monster, MonsterSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleA, _puzzleASpawnPoint.position, Quaternion.identity); 
        Instantiate(_puzzleB, _puzzleBSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleC, _puzzleCSpawnPoint.position, Quaternion.identity);
        _exitHoleInstance = Instantiate(_exitHole, _exitHolePoint.position, Quaternion.identity);
    }

    private void BindGameFlowEvents()
    {
        PuzzleManager.Instance.OnClearAllPuzzles += ActivateExitHole;   
    }

    private void UnbindGameFlowEvents()
    {
        PuzzleManager.Instance.OnClearAllPuzzles -= ActivateExitHole;
    }

    private void ActivateExitHole(bool isActive)
    {
        _exitHoleInstance.SetActive(isActive);
    }
}
