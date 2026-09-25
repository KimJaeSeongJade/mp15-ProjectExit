using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeunghunSceneController : MonoBehaviour
{
    [SerializeField] private KeyCode _pauseKey = KeyCode.Q;

    [SerializeField] private GameObject _pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            ShowPause();
        }
    }
    
    private void ShowPause()
    {
        _pausePanel.SetActive(true);
    }
}
