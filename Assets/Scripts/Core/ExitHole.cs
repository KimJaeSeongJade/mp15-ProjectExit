using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHole : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    
    private void Awake() => gameObject.SetActive(false);
    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayerMask == (1 << other.gameObject.layer))
        {
            GameManager.Instance.ClearGame();
        }
    }
}
