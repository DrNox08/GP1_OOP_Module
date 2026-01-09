using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ICollector
{
    [SerializeField] UI_Inventory inventoryUI;
    List<ICollectible> inventory = new List<ICollectible>();
    

    void AddItemToInventory(ICollectible item)
    {
        inventory.Add(item);
        inventoryUI.UpdateInventory(inventory);
    }

    public void CollectItem(ICollectible item)
    {
        AddItemToInventory(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ICollectible>(out ICollectible collectible))
        {
            collectible.Collect(this);
            Destroy(other.gameObject);
        }
    }
}