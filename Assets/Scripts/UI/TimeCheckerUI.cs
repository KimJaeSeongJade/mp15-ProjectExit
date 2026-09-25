using UnityEngine;
using TMPro;

public class TimeCheckerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmp;

    public void Refresh(int totalSeconds)
    {
        int min = totalSeconds / 60;
        int sec = totalSeconds % 60;
        _tmp.text = $"진행시간 - {min:00} : {sec:00}";
    }
}