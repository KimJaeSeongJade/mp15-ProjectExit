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

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _monster;
    
    [SerializeField] private GameObject _puzzleA;
    [SerializeField] private GameObject _puzzleB;
    [SerializeField] private GameObject _puzzleC;

    private void Start() => Spawn();

    private void Spawn()
    {
        Instantiate(_player, PlayerSpawnPoint.position, Quaternion.identity);
        Instantiate(_monster, MonsterSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleA, _puzzleASpawnPoint.position, Quaternion.identity); 
        Instantiate(_puzzleB, _puzzleBSpawnPoint.position, Quaternion.identity);
        Instantiate(_puzzleC, _puzzleCSpawnPoint.position, Quaternion.identity);
    }
}
