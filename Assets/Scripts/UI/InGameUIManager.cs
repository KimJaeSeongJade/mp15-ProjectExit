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
        
        _pauseQUIContinueButton.onClick.AddListener(OnClickContinue);
        _pauseQUIExitButton.onClick.AddListener(OnClickUIExit);
        
        _clearQUIExitButton.onClick.AddListener(OnClickUIExit);
        _clearQUIAgainButton.onClick.AddListener(OnClickRetryGame);
        
        _deadQUIExitButton.onClick.AddListener(OnClickUIExit);
        _deadQUIAgainButton.onClick.AddListener(OnClickRetryGame);
        
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
        
        _clearQUIExitButton.onClick.RemoveListener(OnClickUIExit);
        _clearQUIAgainButton.onClick.RemoveListener(OnClickRetryGame);
        
        _deadQUIExitButton.onClick.RemoveListener(OnClickUIExit);
        _deadQUIAgainButton.onClick.RemoveListener(OnClickRetryGame);
        
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
        if(!_isPressedDeathKey)
            return;
        
        _deadUI.SetActive(true);
        
        if (_bgm != null)
        {
            _bgm.Stop();
        }
    }

    private void Init()
    {
        _howToPlayUI.SetActive(true);
        
        _pauseQUI.SetActive(false);
        _clearUI.SetActive(false);
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
        OnGameOver();
    }
    
    #if UNITY_EDITOR
    // + Clear 관련
    private KeyCode _clearKey = KeyCode.C; // 임시 설정
    #endif
    
    private bool _isPressedClearKey => Input.GetKeyDown(_clearKey);
    [SerializeField] private Button _clearQUIAgainButton;
    [SerializeField] private Button _clearQUIExitButton;

    public void OnGameClear()
    {
        if(!_isPressedClearKey)
            return;
        
        _clearUI.SetActive(true);
        
        if (_bgm != null)
        {
            _bgm.Stop();
        }
    }

    private void OnClickRetryGame()
    {
        GameManager.Instance.LoadScene("InGameUI");
    }
    
    // + Gameover 관련(Again, Exit)
    private KeyCode _deathKey = KeyCode.V; // 임시 설정
    private bool _isPressedDeathKey => Input.GetKeyDown(_deathKey);
    [SerializeField] private Button _deadQUIAgainButton;
    [SerializeField] private Button _deadQUIExitButton;
    
}
