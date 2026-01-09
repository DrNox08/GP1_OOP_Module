using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] string name = "Coin";
    
    [SerializeField] float rotationSpeed = 90f;
    public string Name { get => name; }
    public void Collect(ICollector collector)
    {
        collector.CollectItem(this);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
