using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.Core.DataStructures;

public class ItemTransferHandler : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] Inventory buildingpodInventory;

    //public List<ItemInfo> allItemInfos = new List<ItemInfo>();    
    public static event Action<int> OnCancelBuild;

    private void Start()
    {
        BuildGolemHandler.OnBuildPressed += AssemblyCleanup;
    }


    private void AssemblyCleanup(BuildGolemHandler command)
    {        
        var allItemInfos = buildingpodInventory.AllItemInfos;

        buildingpodInventory.MainItemCollection.RemoveAll();        
    }

    public void CancelBuild()
    {
        var allItemInfos = buildingpodInventory.AllItemInfos;
        int transferAmount = 0;
        
        for (int i = 0; i < allItemInfos.Count; i++)
        {
            playerInventory.AddItem(allItemInfos[i]);
            transferAmount += 1;
        }

        OnCancelBuild?.Invoke(transferAmount * -1);
        buildingpodInventory.MainItemCollection.RemoveAll();        
    }

    void Update()
    {

    }
}
