using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InteractItems : MonoBehaviour, IJyInteractable
{
    public GameObject InteractItem { get => gameObject; }

    private Transform _grabPoint;
    private Rigidbody _rb;
    private bool _isHold;

    private void Awake() => Init();
    private void Update() => MoveToPlayer();
    
    public void Interact(IJyInteractor owner)
    {
        if (!(owner is JyPlayerController))
        {
            return;
        }
        
        JyPlayerController _player = (JyPlayerController)owner;
        _grabPoint = _player._grabPoint;
        _isHold = true;
        
        if (_rb != null)
        {
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    public void Release()
    {
        _isHold = false;
        _grabPoint = null;

        if (_rb != null)
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }
    }
    
    private void MoveToPlayer()
    {
        if (!_isHold || _grabPoint == null)
        {
            return;
        }

        transform.position = new Vector3(_grabPoint.position.x, _grabPoint.position.y, _grabPoint.position.z);
    }
}
