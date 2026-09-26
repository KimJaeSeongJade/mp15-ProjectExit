using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PuzzleClearListUI : MonoBehaviour
{
    private List<PuzzleBase> _puzzles => GameManager.Instance.Puzzles;

    [SerializeField] private List<TextMeshProUGUI> _tmps;
    [SerializeField] private List<Toggle> _toggles;
    
    private void Start() => StartCoroutine(InitRoutine());
    private void OnEnable() => GameManager.Instance.OnPuzzleCleared += RefreshText;
    
    private void RefreshText()
    {
        for (int i = 0; i < _puzzles.Count; i++)
        {
            string text;
            if (_puzzles[i].IsClear)
            {
                text = $"<s>미션 {i + 1} : {_puzzles[i].Name}</s>";
                _toggles[i].isOn = true;
            }
            else
            {
                text = $"미션 {i + 1} : {_puzzles[i].Name}";
                _toggles[i].isOn = false;
            }

            _tmps[i].text = text;
        }
    }

    private IEnumerator InitRoutine()
    {
        OffToggles();
        
        yield return new WaitUntil(() => _puzzles.Count > 0);
        RefreshText();
    }

    private void OffToggles()
    {
        foreach (Toggle toggle in _toggles)
        {
            toggle.isOn = false;
        }
    }
}
