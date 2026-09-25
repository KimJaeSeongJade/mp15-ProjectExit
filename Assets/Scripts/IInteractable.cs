using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject GameObject { get; }

    // 상호 작용을 당할 때 누군지 알아야 한다.
    public void Interact(IInteractor owner);
}
