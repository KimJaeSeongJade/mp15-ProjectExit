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
    [SerializeField] private GameObject _gripUI;
    [SerializeField] private GameObject _playerHpUI;

    [SerializeField] private AudioClip _bgmAudioClip;
    private AudioPlayer _bgm;

    private bool _endSignal => GameManager.Instance.IsGameClear;
    
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
    
    // Test---
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (PuzzleBase p in GameManager.Instance.Puzzles)
            {
                p.IsClear = true;
            }
        }
    }

    private void BindButtonEvents()
    {
        _howToPlayUIStartButton.onClick.AddListener(PressToPlay);
        
        _pauseQUIContinueButton.onClick.AddListener(OnClickContinue);
        _pauseQUIExitButton.onClick.AddListener(OnClickUIExit);
    }

    private void BindGameFlowEvents()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGamePause += OnGamePause;
        GameManager.Instance.OnGameResume += OnGameResume;
        GameManager.Instance.OnGameOver += OnGameOver;
        GameManager.Instance.OnGameClear += OnGameClear;
    }

    private void UnbindGameFlowEvents()
    {
        if (GameManager.Instance == null)
            return;
        
        GameManager.Instance.OnGameStart -= OnGameStart;
        GameManager.Instance.OnGamePause -= OnGamePause;
        GameManager.Instance.OnGameResume -= OnGameResume;
        GameManager.Instance.OnGameOver -= OnGameOver;
        GameManager.Instance.OnGameClear -= OnGameClear;
    }

    private void UnbindButtonEvents()
    {
        if (GameManager.Instance == null)
            return;
        
        _howToPlayUIStartButton.onClick.RemoveListener(PressToPlay);
        
        _pauseQUIContinueButton.onClick.RemoveListener(OnClickContinue);
        _pauseQUIExitButton.onClick.RemoveListener(OnClickUIExit);
    }

    private void BeforePlaying() =>GameManager.Instance.PauseGame();
    private void PressToPlay() => GameManager.Instance.StartGame();
    private void OnClickContinue() => GameManager.Instance.ResumeGame();
    private void OnClickUIExit()
    {
        GameManager.Instance.LoadScene("GameTitle");
        
        if (_bgm != null)
        {
            _bgm.Stop();
        }
    }
    
    private void OnGameStart()
    {
        _howToPlayUI.SetActive(false);
        _inGameUI.SetActive(true);
        _playerHpUI.SetActive(true);
        _gripUI.SetActive(false);
        _pauseQUI.SetActive(false);

        BgmInit();
    }

    private void OnGamePause()
    {
        if(!_isPressedPauseKey)
            return;
        
        _pauseQUI.SetActive(true);

        if (_bgm != null)
        {
            _bgm.Pause();
        }
    }

    private void OnGameResume()
    {
        _pauseQUI.SetActive(false);

        if (_bgm != null)
        {
            _bgm.Play();
        }
    }
    
    private void OnGameOver()
    {
        _deadUI.SetActive(true);
        
        if (_bgm != null)
        {
            _bgm.Stop();
        }
    }

    private void Init()
    {
        GameManager.Instance.RestartGame();
        
        _clearUI.SetActive(false);
        _howToPlayUI.SetActive(true);
        
        _pauseQUI.SetActive(false);
        _deadUI.SetActive(false);
        _inGameUI.SetActive(false);
        _playerHpUI.SetActive(false);
        
        BeforePlaying();
    }

    private void BgmInit()
    {
        if (_bgm == null)
        {
            _bgm = AudioManager.Instance.TakeAudioPlayer();
            _bgm
                .SetLoop(true)
                .SetVolume(0.5f)
                .SetAudioClip(_bgmAudioClip)
                .PlayOnAwake(true)
                .Play();
        }
    }
    
    // + InGamePause 관련
    [SerializeField] private KeyCode _pauseKey = KeyCode.Q;
    private bool _isPressedPauseKey => Input.GetKeyDown(_pauseKey);
    
    [SerializeField] private Button _pauseQUIExitButton;
    [SerializeField] private Button _pauseQUIContinueButton;

    private void LateUpdate()
    {
        OnGamePause();
        OnGameClear();
    }

    private void OnGameClear()
    {
        if(!_endSignal)
            return;
        
        _clearUI.SetActive(true);     
        if (_bgm != null)
        {      
            _bgm.Stop();    
        }    
    }

    private void OnClickRetryGame()
    {
        _clearUI.SetActive(false);
        GameManager.Instance.LoadScene("MainGame");
    }
    
    
}
