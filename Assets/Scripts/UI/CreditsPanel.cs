using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsPanel : MonoBehaviour
{
    [SerializeField] private Button _cancelButton;

    private void OnEnable() => BindButtonEvents();
    private void Start() => HidePanel();
    private void OnDisable() => UnbindButtonEvents();
    
    private void BindButtonEvents()
    {
        _cancelButton.onClick.AddListener(HidePanel);
    }

    private void UnbindButtonEvents()
    {
        _cancelButton.onClick.RemoveListener(HidePanel);
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
