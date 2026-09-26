using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<PuzzleBase> _puzzles = new(3);
    public List<PuzzleBase> Puzzles => _puzzles;
    public Action OnPuzzleCleared;

    public event Action OnGameStart;
    public event Action OnGameOver;
    public event Action OnGamePause;
    public event Action OnGameResume;
    public event Action OnGameClear;

    public GameObject ExitHole { get; set; }
    public bool IsGameClear { get; private set; }

    private void Awake() => SetSingleton();

    // TODO: GameManager가 담당해야 할 게임의 시작/정지/재개/종료에 대한 처리는 여기서 담당합니다.
    
    public void StartGame()
    {
        OnGameStart?.Invoke();
        Time.timeScale = 1;
        IsGameClear = false;
        // 이후 필요한 로직 작성
    }

    public void PauseGame()
    {
        OnGamePause?.Invoke();
        Time.timeScale = 0;
        // 이후 필요한 로직 작성
    }
    
    public void ResumeGame()
    {
        OnGameResume?.Invoke();
        Time.timeScale = 1;
        // 이후 필요한 로직 작성
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        Time.timeScale = 0;
        // 이후 필요한 로직 작성
    }

    public void ClearGame()
    {
        IsGameClear = true;
        OnGameClear?.Invoke();
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddPuzzle(PuzzleBase puzzle)
    {
        _puzzles.Add(puzzle);
    }

    public void RemovePuzzle(PuzzleBase puzzle)
    {
        _puzzles.Remove(puzzle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (PuzzleBase p in _puzzles)
            {
                p.IsClear = true;
            }
        }
    }
}
