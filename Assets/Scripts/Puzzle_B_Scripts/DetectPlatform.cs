using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _blockLayer; // 레이어 마스크 = 블록만 판단
    [field : SerializeField] public GameObject[] _blocks { get; private set; } // 타일을 이루고 있는 블록들

    private bool isTouchOutside;// 블록이 밖으로 빠져나갔는지
    private bool isTileFull // 타일이 9칸 다 채워졌는가
    {
        get { return triggerCount == 9; }
    }

    public bool isClear { get; private set; } // 클리어 했는가
    public int triggerCount; // 채워진 타일 칸 수
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TileTrigger();
        }

        IsClear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            isTouchOutside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            isTouchOutside = false;
        }
    }

    private void IsClear()
    {
        if (!isTileFull || isTouchOutside)
        {
            return;
        }
        else if (isTileFull && !isTouchOutside)
        {
            isClear = true;
            Debug.Log("IsClear : 클리어!");
        }
    }
    
    private void TileTrigger()
    {
        triggerCount = 0;
        for (int i = 0; i < _blocks.Length; i++)
        {
            Ray ray = new Ray(_blocks[i].transform.position, _blocks[i].transform.up);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 1f, _blockLayer) && hit.transform != null)
            {
                Debug.Log($"{_blocks[i].name} : 블록 감지");
                triggerCount++;
                
            }
        }
        Debug.Log($"현재 채워진 타일 : {triggerCount}칸");
    }
}
