using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JyPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _grabPoint;
    private void Update()
    {
        PlayerMoveInputControll();
    }
    
    private void PlayerMoveInputControll()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }
}
