using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCManager : PuzzleBase
{
    [SerializeField] private List<GoalPointSm> _goalPoints = new();
    // [SerializeField] private GameObject _clearUI;

    private void Awake()
    {
        if (_goalPoints.Count == 0)
            _goalPoints.AddRange(FindObjectsOfType<GoalPointSm>());

        foreach (var goalPoint in _goalPoints)
        {
            goalPoint.OnClearStateChanged += HandleGoalPointClearChanged;
        }
        // _clearUI.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.AddPuzzle(this);
    }

    private void OnDestroy()
    {
        foreach (var goalPoint in _goalPoints)
        {
            if (goalPoint != null)
                goalPoint.OnClearStateChanged -= HandleGoalPointClearChanged;
        }
        
        GameManager.Instance.RemovePuzzle(this);
    }

    private void HandleGoalPointClearChanged(bool isCheck)
    {
        CheckAllClear();
    }

    private void CheckAllClear()
    {
        foreach (var goalPoint in _goalPoints)
        {
            if (goalPoint == null || !goalPoint._isClearThisSecter)
                return;
        }

        GameClear();
    }

    private void GameClear()
    {
        Debug.Log("Game Clear!");

        // if (_clearUI != null) _clearUI.SetActive(true);
        IsClear = true;
    }
}