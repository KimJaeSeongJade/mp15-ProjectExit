using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InteractItems : MonoBehaviour, IJyInteractable
{
    public GameObject GmObject { get => gameObject; }
    private JyPlayerController _playerController;
    
    private Transform _getGrapPoint;
    [SerializeField] private GoalPoint _goalPoint;
    
    private void Awake() => Init();
    
    private void FixedUpdate()
    {
        FollowPlayer();
    }
    
    private void OnDestroy()
    {
        if (_goalPoint != null)
            _goalPoint.OnClearStateChanged -= HandleClearStateChanged;
    }
    
    public void Interact(IJyInteractor owner)
    {
        if (!(owner is JyPlayerController))
            return;

        _playerController = (JyPlayerController)owner;

        _getGrapPoint = _playerController.GrapPoint;
        
        transform.position = _getGrapPoint.position;
        
        //Destroy(gameObject);
    }

    private void FollowPlayer()
    {
        if (_playerController == null) 
            return;
        
        transform.Translate(_playerController.GetPlayerRigidbody.velocity * Time.deltaTime, Space.World);
    }

    private void Init()
    {
        if (_goalPoint == null)
            _goalPoint = FindObjectOfType<GoalPoint>(); // 씬에 하나뿐이라면

        if (_goalPoint != null)
            _goalPoint.OnClearStateChanged += HandleClearStateChanged;

    }
    
    private void HandleClearStateChanged(bool isClear)
    {
        if (isClear)
        {
            Destroy(gameObject);
        }
    }
}
