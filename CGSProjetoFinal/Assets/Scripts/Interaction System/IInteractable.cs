using UnityEngine;

public interface IInteractable
{
    public Transform transform { get;  }
    public bool Interact(Interactor interactor);
}
