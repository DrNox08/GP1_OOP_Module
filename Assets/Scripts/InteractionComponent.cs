using System;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask interactableLayer;

    [Header("UI")]
    [SerializeField] UI_Interactable interactableUI;

    GameObject currentInteractable;


    private void Update()
    {
        currentInteractable = null;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, interactableLayer);

        if (colliders.Length <= 0)
        {
            interactableUI.UpdateUI(string.Empty);
            return;
        }

        // Get the closest interactable object
        float closestDistance = float.MaxValue;

        foreach (var coll in colliders)
        {
            float distance = Vector3.Distance(transform.position, coll.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentInteractable = coll.gameObject;
                interactableUI.UpdateUI(currentInteractable.name);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            if (currentInteractable.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                currentInteractable = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}