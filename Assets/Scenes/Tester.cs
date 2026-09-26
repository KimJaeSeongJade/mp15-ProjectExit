using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _pauseUI.SetActive(true);
            GameManager.Instance.PauseGame();
        }
    }
}
