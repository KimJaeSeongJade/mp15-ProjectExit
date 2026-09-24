using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCManager : MonoBehaviour
{
    
    [SerializeField] private List<GoalPoint> _goalPoints = new();
    [SerializeField] private GameObject _clearUI;

    private void Awake()
    {
        if (_goalPoints.Count == 0)
            _goalPoints.AddRange(FindObjectsOfType<GoalPoint>());

        foreach (var goalPoint in _goalPoints)
        {
            goalPoint.OnClearStateChanged += HandleGoalPointClearChanged;
        }
        _clearUI.SetActive(false);
    }

    private void OnDestroy()
    {
        foreach (var goalPoint in _goalPoints)
        {
            if (goalPoint != null)
                goalPoint.OnClearStateChanged -= HandleGoalPointClearChanged;
        }
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

        if (_clearUI != null)
            _clearUI.SetActive(true);
    }
}