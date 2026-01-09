using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots;
    List<string> itemNames = new List<string>();
    
    int ownedPotions = 0;
    int ownedCoins = 0;

    private void Awake()
    {
        foreach (GameObject slot in inventorySlots)
        {
            slot.SetActive(false);
        }
    }

    public void UpdateInventory(List<ICollectible> items)
    {
        ownedPotions = 0;
        ownedCoins = 0;
        
        foreach (ICollectible item in items)
        {
            switch (item.Name)
            {
                case "Potion":
                    ownedPotions++;
                    if(!inventorySlots[0].activeInHierarchy) inventorySlots[0].SetActive(true);
                    inventorySlots[0].GetComponentInChildren<TMP_Text>().text = item.Name + ": " + ownedPotions.ToString();
                    break;
                case "Coin":
                    ownedCoins++;
                    if(!inventorySlots[1].activeInHierarchy) inventorySlots[1].SetActive(true);
                    inventorySlots[1].GetComponentInChildren<TMP_Text>().text = item.Name + ": " + ownedCoins.ToString();
                    break;
            }
        }
        
    }
}
