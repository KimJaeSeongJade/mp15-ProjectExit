using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerCont : MonoBehaviour, IDamageable
{
    [SerializeField] private float _moveSpeed;
    private void Update()
    {
        ReadMoveInput();
    }
    
    private void ReadMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z).normalized;
        
        transform.Translate(dir * _moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player had Damaged {damage}");
    }
}
