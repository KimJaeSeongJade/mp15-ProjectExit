using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearMiniUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _clearText;

    private void Awake()
    {
       _clearText.enabled = false;
    }

    private void OnDestroy()
    {
        _clearText.enabled = true;
    }
}
