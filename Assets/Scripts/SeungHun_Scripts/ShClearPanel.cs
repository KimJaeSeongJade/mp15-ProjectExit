using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShClearPanel : MonoBehaviour
{
    [SerializeField] private Button _againButton;
    [SerializeField] private Button _exitButton;

    private void Start() => BindButtonEvents();
    
    private void OnDisable() => UnBindButtonEvents();
    
    private void BindButtonEvents()
    {
        _againButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(GoToTitle);
    }
    
    private void UnBindButtonEvents()
    {
        _againButton.onClick.RemoveListener(RestartGame);
        _exitButton.onClick.RemoveListener(GoToTitle);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("GameTitle");
    }
}
