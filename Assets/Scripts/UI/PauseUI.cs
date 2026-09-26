using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playTime;
    [SerializeField] private List<TextMeshProUGUI> _tmps;
    [SerializeField] private List<Toggle> _toggles;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TimeChecker _timeChecker;
    [SerializeField] private string _titleScene;
    
    private List<PuzzleBase> _puzzles => GameManager.Instance.Puzzles;

    private void OnEnable()
    {
        BindButtonEvents();
        RefreshPuzzleList();
        RefreshPlayTime();
    }
    private void Start() => gameObject.SetActive(false);
    private void OnDisable() => UnbindButtonEvents();

    private void BindButtonEvents()
    {
        _continueButton.onClick.AddListener(Continue);
        _exitButton.onClick.AddListener(Exit);
    }

    private void UnbindButtonEvents()
    {
        _continueButton.onClick.RemoveListener(Continue);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void RefreshPlayTime()
    {
        int totalSeconds = _timeChecker.CurrentSecond;
        int min = totalSeconds / 60;
        int sec = totalSeconds % 60;
        _playTime.text = $"진행시간 - {min:00} : {sec:00}";
    }

    private void RefreshPuzzleList()
    {
        if (_puzzles == null && _puzzles.Count == 0) return;
        
        for (int i = 0; i < _puzzles.Count; i++)
        {
            if (_puzzles[i].IsClear)
            {
                _tmps[i].text = $"<s>미션 1 : {_puzzles[i].Name}</s>";
                _toggles[i].isOn = true;
            }
            else
            {
                _tmps[i].text = $"미션 1 : {_puzzles[i].Name}";
                _toggles[i].isOn = false;
            }
        }
    }
    
    private void Continue()
    {
        GameManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }

    private void Exit()
    {
        GameManager.Instance.LoadScene(_titleScene);
    }
}
