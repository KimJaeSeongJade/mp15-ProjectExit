using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [SerializeField] private Transform _exitSpawnPoint;
    [SerializeField] private GameObject _exit;

    
    
    private void PuzzleClear()
    {
        Instantiate(_exit,  _exitSpawnPoint.position, Quaternion.identity);
    }
}