using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiRot : MonoBehaviour
{
    void Update()
    {
        Moving();
    }
    private void Moving()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20 , Space.World);
        
    }
}
