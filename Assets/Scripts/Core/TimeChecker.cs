using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    [SerializeField] private TimeCheckerUI _timeCheckerUI;

    private float _elapsedTime = 0f;
    private int _lastSecond = -1;

    public int CurrentSecond { get; private set; }

    private void Start() => ResetTimer();
    private void Update() => UpdateTime();

    private void UpdateTime()
    {
        _elapsedTime += Time.deltaTime;

        CurrentSecond = (int)_elapsedTime;
        if (CurrentSecond == _lastSecond) return;

        _lastSecond = CurrentSecond;
        _timeCheckerUI.Refresh(CurrentSecond);
    }

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        _lastSecond = 0;
        _timeCheckerUI.Refresh(0);
    }
}