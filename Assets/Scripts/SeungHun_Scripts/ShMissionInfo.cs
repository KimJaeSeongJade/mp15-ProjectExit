using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShMissionInfo : MonoBehaviour
{
    [SerializeField] private Toggle _clearToggleA;
    [SerializeField] private Toggle _clearToggleB;
    [SerializeField] private Toggle _clearToggleC;
    [SerializeField] private TextMeshProUGUI _playTimeText;
    
    private float _playTimeSecond;
    private int _playTimeMinute;

    private void Awake() => InitToggles();
    
    private void InitToggles()
    {
        _clearToggleA.isOn = false;
        _clearToggleB.isOn = false;
        _clearToggleC.isOn = false;
    }

    private void Update()
    {
        CountPlayTime();
        UpdatePlayTimeText();
    }

    private void CountPlayTime() // 60초가 넘어가면 1분으로 바꿔줍니다.
    {
        _playTimeSecond += Time.deltaTime;
        if (_playTimeSecond >= 59f)
        {
            _playTimeSecond = 0f;
            _playTimeMinute++;
        }
    }

    private void UpdatePlayTimeText() // 플레이타임 문구 갱신하는 메서드입니다.
    {
        if (_playTimeMinute <= 9)
        {
            if (_playTimeSecond <= 9f)
            {
                _playTimeText.text = $"Play Time 0{_playTimeMinute} : 0{Convert.ToInt32(_playTimeSecond)}";
            }
            else if (_playTimeSecond >= 10f)
            {
                _playTimeText.text = $"Play Time 0{_playTimeMinute} : {Convert.ToInt32(_playTimeSecond)}";
            }
            
        }
        else if (_playTimeMinute >= 10)
        {
            if (_playTimeSecond <= 9f)
            {
                _playTimeText.text = $"Play Time {_playTimeMinute} : 0{Convert.ToInt32(_playTimeSecond)}";
            }
            else if (_playTimeSecond >= 10f)
            {
                _playTimeText.text = $"Play Time {_playTimeMinute} : {Convert.ToInt32(_playTimeSecond)}";
            }
            
        }
    }
}
