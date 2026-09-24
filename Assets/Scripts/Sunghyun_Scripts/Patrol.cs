using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Pattern
{
    [SerializeField] private List<Vector3> _wayPoints;
    
    private int _currentWayPoint = 0;


    public override void OnAction()
    {
        
    }


}
