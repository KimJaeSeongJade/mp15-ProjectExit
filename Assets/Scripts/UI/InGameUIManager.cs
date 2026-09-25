using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _howToPlayUI;
    [SerializeField] private GameObject _pauseQUI;
    [SerializeField] private GameObject _clearUI;
    [SerializeField] private GameObject _deadUI;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private Button _howToPlayUIStartButton;

    private void Awake() => Init();

    private void OnEnable()
    {
        BindButtonEvents();
        BindGameFlowEvents();
    }

    private void OnDisable()
    {
        UnbindButtonEvents();
        UnbindGameFlowEvents();
    }

    private void BindButtonEvents()
    {
        _howToPlayUIStartButton.onClick.AddListener(PressToPlay);
    }

    private void BindGameFlowEvents()
    {
        GameManager.Instance.OnGamePause += Init;
        GameManager.Instance.OnGameStart += OnGameStart;

    }

    private void UnbindGameFlowEvents()
    {
        GameManager.Instance.OnGamePause -= Init;
        GameManager.Instance.OnGameStart -= OnGameStart;
    }

    private void UnbindButtonEvents()
    {
        _howToPlayUIStartButton.onClick.RemoveListener(PressToPlay);
    }

    private void BeforePlaying() =>GameManager.Instance.PauseGame();
    private void PressToPlay() => GameManager.Instance.StartGame();

    private void OnGameStart()
    {
        _howToPlayUI.SetActive(false);
        _inGameUI.SetActive(true);
    }

    private void Init()
    {
        _howToPlayUI.SetActive(true);
        
        _pauseQUI.SetActive(false);
        _clearUI.SetActive(false);
        _deadUI.SetActive(false);
        _inGameUI.SetActive(false);
        BeforePlaying();
    }
}
