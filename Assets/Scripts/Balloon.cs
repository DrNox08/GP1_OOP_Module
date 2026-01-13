using System.Collections;
using UnityEngine;

public class Balloon : BaseInteractable
{
    [SerializeField] string name = "Balloon";
    [SerializeField] float expandDuration = 1f;
    [SerializeField] Vector3 targetScale = Vector3.one;
    
    public override string Name => name;
    
    public override void Interact()
    {
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        StartCoroutine(Expand());
    }

    IEnumerator Expand()
    {
        float elapsedTime = 0f;
        Vector3 originalScale = transform.localScale;
        targetScale = originalScale * 1.5f;
        while (elapsedTime < expandDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, (elapsedTime / expandDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
