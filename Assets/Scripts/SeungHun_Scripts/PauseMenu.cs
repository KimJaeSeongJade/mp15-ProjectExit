using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _exit; // 타이틀로 돌아가는 버튼
    [SerializeField] private Button _continue; // 패널을 닫는 버튼

    private void OnEnable()
    {
        BindButtonEvents();
    }

    private void OnDisable()
    {
        UnBindButtonEvents();
    }

    private void Start() => HidePanel();
    
    private void BindButtonEvents()
    {
        _continue.onClick.AddListener(HidePanel);
        _exit
    }

    private void UnBindButtonEvents()
    {
        _continue.onClick.RemoveListener(HidePanel);
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("GameTitle");
    }
}
