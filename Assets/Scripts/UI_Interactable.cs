using System;
using TMPro;
using UnityEngine;

public class UI_Interactable : MonoBehaviour
{
    [SerializeField] TMP_Text interactionText;

    private void Awake()
    {
        interactionText.gameObject.SetActive(false);
    }

    public void UpdateUI(string interactableName)
    {
        if (interactableName != string.Empty)
        {
            interactionText.text = "Press E to interact with: " + interactableName;
            interactionText.gameObject.SetActive(true);
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
