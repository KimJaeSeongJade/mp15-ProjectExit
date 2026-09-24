using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Awake() => SetSingleton();

    public event Action OnGameStart;
    public event Action OnGameOver;
    public event Action OnGamePause;
    public event Action OnGameResume;

    // TODO: GameManager가 담당해야 할 게임의 시작/정지/재개/종료에 대한 처리는 여기서 담당합니다.
    
    public void StartGame()
    {
        OnGameStart?.Invoke();
        // Time.timeScale = 1;
        // 이후 필요한 로직 작성
    }

    public void PauseGame()
    {
        OnGamePause?.Invoke();
        // Time.timeScale = 0;
        // 이후 필요한 로직 작성
    }

    public void ResumeGame()
    {
        OnGameResume?.Invoke();
        // Time.timeScale = 1;
        // 이후 필요한 로직 작성
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        // Time.timeScale = 0;
        // 이후 필요한 로직 작성
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
