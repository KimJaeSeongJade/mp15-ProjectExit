using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [field: SerializeField] public int PlayerHealth { get; set; } = 100;
    [field: SerializeField] public float MoveSpeed { get; set; } = 5f;

    [field: SerializeField] public float InteractRange { get; set; } = 10f;
}
