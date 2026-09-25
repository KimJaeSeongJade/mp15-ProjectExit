using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    [SerializeField] private TimeCheckerUI _timeCheckerUI;

    private float _elapsedTime = 0f;
    private int _lastSecond = -1;

    private void Start() => ResetTimer();
    private void Update() => UpdateTime();

    private void UpdateTime()
    {
        _elapsedTime += Time.deltaTime;

        int currentSecond = (int)_elapsedTime;
        if (currentSecond == _lastSecond) return;

        _lastSecond = currentSecond;
        _timeCheckerUI.Refresh(currentSecond);
    }

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        _lastSecond = 0;
        _timeCheckerUI.Refresh(0);
    }
}