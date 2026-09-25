using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanelUI : MonoBehaviour
{
    [SerializeField] private Button _againButton;
    [SerializeField] private Button _exitButton;
    
    [SerializeField] private TimeChecker _timeChecker;
    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private string _titleScene;
    [SerializeField] private string _gameScene;

    private void OnEnable()
    {
        BindButtonEvents();
        RefreshClearTime();
    }

    private void Start() => gameObject.SetActive(false);

    private void OnDisable() => UnbindButtonEvents();
    
    private void BindButtonEvents()
    {
        _againButton.onClick.AddListener(Again);
        _exitButton.onClick.AddListener(Exit);
    }

    private void UnbindButtonEvents()
    {
        _againButton.onClick.RemoveListener(Again);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void Again()
    {
        GameManager.Instance.LoadScene(_gameScene);
    }

    private void Exit()
    {
        GameManager.Instance.LoadScene(_titleScene);
    }

    public void RefreshClearTime()
    {
        int min = _timeChecker.CurrentSecond / 60;
        int sec = _timeChecker.CurrentSecond % 60;
        _timeText.text = $"진행시간 - {min:00} : {sec:00}";
    }
}
