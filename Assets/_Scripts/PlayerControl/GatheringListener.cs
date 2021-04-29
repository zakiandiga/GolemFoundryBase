using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;

public class GatheringListener : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();    
    }

    private void OnEnable()
    {
        GatheringAnnouncer.OnGatheringMaterial += AddGatheredMaterial;
    }

    private void OnDisable()
    {
        GatheringAnnouncer.OnGatheringMaterial -= AddGatheredMaterial;
    }

    private void AddGatheredMaterial(Item item, int amount)
    {
        inventory.AddItem(item.ItemDefinition, amount);
    }
}
