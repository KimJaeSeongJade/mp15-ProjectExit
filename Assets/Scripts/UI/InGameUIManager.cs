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
        _pauseQUIExitButton.onClick.AddListener(OnGamePause);
        _pauseQUIContinueButton.onClick.AddListener(OnClickPauseUIContinue);
        _pauseQUIExitButton.onClick.AddListener(OnClickPauseUIExit);
    }

    private void BindGameFlowEvents()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGamePause += OnGamePause;
        GameManager.Instance.OnGameResume += OnGameResume;
    }

    private void UnbindGameFlowEvents()
    {
        GameManager.Instance.OnGameStart -= OnGameStart;
        GameManager.Instance.OnGamePause -= OnGamePause;
        GameManager.Instance.OnGameResume -= OnGameResume;
    }

    private void UnbindButtonEvents()
    {
        _howToPlayUIStartButton.onClick.RemoveListener(PressToPlay);
        _pauseQUIExitButton.onClick.RemoveListener(OnGamePause);
        _pauseQUIContinueButton.onClick.RemoveListener(OnClickPauseUIContinue);
        _pauseQUIExitButton.onClick.RemoveListener(OnClickPauseUIExit);
    }

    private void BeforePlaying() =>GameManager.Instance.PauseGame();
    private void PressToPlay() => GameManager.Instance.StartGame();
    private void OnClickPauseUIContinue() => GameManager.Instance.ResumeGame();
    private void OnClickPauseUIExit()
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
        _howToPlayUI.SetActive(true);
        
        _pauseQUI.SetActive(false);
        _clearUI.SetActive(false);
        _deadUI.SetActive(false);
        _inGameUI.SetActive(false);
        
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
    }
    
    // + Clear 관련
    private KeyCode _clearKey = KeyCode.C; // 임시 설정
    private bool _isPressedClearKey => Input.GetKeyDown(_clearKey);
    [SerializeField] private Button _clearQUIAgainButton;
    [SerializeField] private Button _clearQUIExitButton;

    private void OnGameClear()
    {
        
    }
}
