using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;

public class RefillMaterial : MonoBehaviour
{
    Inventory playerInventory;
    [SerializeField] Inventory refillerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }
    public void RefillInfentory()
    {
        var allItemInfos = refillerInventory.AllItemInfos;

        for (int i = 0; i < allItemInfos.Count; i++)
        {
            playerInventory.AddItem(allItemInfos[i]);
        }
    }
}
