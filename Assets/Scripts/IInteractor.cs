using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractor
{
    public GameObject GameObject { get; }
    public void TryInteract();

    // 플레이어와 아이템을 상호작용 할 수 있는
}
