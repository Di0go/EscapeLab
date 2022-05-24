using UnityEngine;

public interface IInteractable
{
    public string intText { get; }
    public Transform transform { get;  }
    public bool Interact();
}
