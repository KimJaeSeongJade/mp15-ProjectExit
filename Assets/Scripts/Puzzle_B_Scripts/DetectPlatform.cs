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
    
    public int triggerCount; // 채워진 타일 칸 수

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

    private void Update()
    {
        DetectBlocks();
        CanClearPuzzle();
    }

    // 타일이 다 채워졌고, 밖으로 빠져나간게 없다면 클리어 조건을 채웁니다.
    public bool CanClearPuzzle()
    {
        if (isTileFull && !isTouchOutside)
        {
            return true;
        }
        return false;
    }
    
    // 자식 블록들이 Raycast로 블록을 감지, 총 갯수를 셉니다
    private void DetectBlocks()
    {
        triggerCount = 0;
        for (int i = 0; i < _blocks.Length; i++)
        {
            Ray ray = new Ray(_blocks[i].transform.position, _blocks[i].transform.up);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 1f, _blockLayer) && hit.transform != null)
            {
                triggerCount++;
            }
        }
    }
}
