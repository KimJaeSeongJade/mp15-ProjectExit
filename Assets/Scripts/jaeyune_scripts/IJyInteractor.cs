using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJyInteractor
{
    public GameObject InteractTarget { get; }
    public void TryInteract();
}
