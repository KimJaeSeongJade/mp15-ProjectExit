using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHole : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    private void Awake() => gameObject.SetActive(false);
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered if");
        if (_playerLayerMask == (1 << other.gameObject.layer))
        {
            Debug.Log("Progressing if");
            GameManager.Instance.ClearGame();
        }
        Debug.Log("Exited if");
    }
}
