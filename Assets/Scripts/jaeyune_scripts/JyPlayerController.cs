using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JyPlayerController : MonoBehaviour, IJyInteractor
{
    [SerializeField] private float _moveSpeed;
    
    [field: SerializeField] public Transform _grabPoint;
    [SerializeField] private Transform _interactPoint;
    
    [SerializeField] private float _interactDistance;
    [SerializeField] private LayerMask _interactLayer;
    
    private IJyInteractable _interactTarget;
    private IJyInteractable _holdItem;
    
    
    private void Update()
    {
        PlayerMoveInputControll();
        DetectInteractable();

        GetInteract();
    }
    
    private void PlayerMoveInputControll()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }

    public GameObject InteractTarget { get => gameObject; }
    
    public void TryInteract()
    {
        if (_holdItem != null)
        {
            ReleaseItem();
            return;
        }

        if (_interactTarget != null)
        {
            _interactTarget.Interact(this);
            _holdItem = _interactTarget;
        }
    }

    private void DetectInteractable()
    {
        if (_holdItem != null)
        {
            _interactTarget = null;
            return;
        }
        
        Ray ray = new Ray(_interactPoint.position, _interactPoint.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, _interactDistance, _interactLayer))
        {
            _interactTarget = hit.collider.GetComponentInParent<IJyInteractable>();
        }
        else
        {
            _interactTarget = null;
        }
    }
    
    private void ReleaseItem()
    {
        if (_holdItem is InteractItems item)
        {
            item.Release();
        }
       _holdItem = null;
    }

    private void GetInteract()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
            Debug.Log("Try Interact");
        }
    }
}
