using UnityEngine;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    public virtual string Name => "Base Interactable";

    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + Name);
    }
}
