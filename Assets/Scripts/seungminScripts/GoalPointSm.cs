using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoalPointSm : MonoBehaviour
{
    [SerializeField] private string targetItem;
    
    public bool _isClearThisSecter = false;
    
    public event Action<bool> OnClearStateChanged;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetItem))
        {
            Debug.Log($"GoalPoint: {targetItem} entered.");
            _isClearThisSecter = true;
            OnClearStateChanged?.Invoke(_isClearThisSecter);
            Debug.Log($"GoalPoint 판정: {_isClearThisSecter}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetItem))
        {
            Debug.Log($"GoalPoint: {targetItem} exited.");
        }
    }
}
