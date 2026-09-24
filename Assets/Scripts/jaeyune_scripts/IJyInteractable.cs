using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJyInteractable
{
    public GameObject InteractItem { get; }
    
    public void Interact(IJyInteractor owner);
}
