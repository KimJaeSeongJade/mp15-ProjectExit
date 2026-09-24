using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _creditsButton;
    
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private string _gameScene;

    [SerializeField] private AudioClip _bgmClip;

    private AudioPlayer _bgm;
    
    private void OnEnable() => BindButtonEvents();
    private void Start() => PlayBgm();
    private void OnDisable() => UnbindButtonEvents();
    private void OnDestroy() => StopBgm();

    private void PlayBgm()
    {
        _bgm = AudioManager.Instance.TakeAudioPlayer();

        if (_bgmClip == null) return;
        
        _bgm
            .SetLoop(true)
            .SetVolume(0.5f)
            .PlayOnAwake(true)
            .SetAudioClip(_bgmClip)
            .Play();
    }

    private void StopBgm()
    {
        _bgm.Stop();
        _bgm = null;
    }

    private void BindButtonEvents()
    {
        _startButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(QuitGame);
        _creditsButton.onClick.AddListener(ShowCredits);
    }

    private void UnbindButtonEvents()
    {
        _startButton.onClick.RemoveListener(StartGame);
        _quitButton.onClick.RemoveListener(QuitGame);
        _creditsButton.onClick.RemoveListener(ShowCredits);
    }

    private void StartGame()
    {
        GameManager.Instance.LoadScene(_gameScene);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ShowCredits()
    {
        _creditsPanel.SetActive(true);
    }
}
