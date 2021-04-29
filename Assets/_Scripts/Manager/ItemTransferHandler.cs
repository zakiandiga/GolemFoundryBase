using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using Opsive.UltimateInventorySystem.Input;

public class ItemTransferHandler : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] Inventory buildingpodInventory;

    private int transferAmount = 0;

    //public List<ItemInfo> allItemInfos = new List<ItemInfo>();    
    public static event Action<int> OnRefreshTransfer;
    //public static event Action<string> OnInventoryCleanup;

    private void Start()
    {

    }

    private void OnEnable()
    {
        BuildGolemHandler.OnBuildPressed += BuildCleanup;
        //UIS_CustomInput.OnClosingBuildMenu += CancelCue;
        UIS_CustomInput.OnCancelBuild += CancelCue; //OLD
        MenuControl.OnCancelBuild += CancelCue;  //NEW
    }

    private void OnDisable()
    {
        BuildGolemHandler.OnBuildPressed -= BuildCleanup;
        //UIS_CustomInput.OnClosingBuildMenu += CancelCue;
        UIS_CustomInput.OnCancelBuild -= CancelCue;  //OLD
        
        MenuControl.OnCancelBuild -= CancelCue; //NEW
    }


    private void BuildCleanup(string announcer)
    {        
        var allItemInfos = buildingpodInventory.AllItemInfos;

        //OnRefreshTransfer?.Invoke(allItemInfos.Count * -1);

        
        buildingpodInventory.MainItemCollection.RemoveAll();
        

        //OnInventoryCleanup?.Invoke("buildCleanup");
              
    }

    private void CancelCue(string announcer)
    {
        if(announcer == "blueprintGrid")
        {
            CancelBuild();
        }
    }

    public void CancelBuild() //triggered from button and CancelCue()
    {
        var allItemInfos = buildingpodInventory.AllItemInfos;
        
        
        for (int i = 0; i < allItemInfos.Count; i++)
        {
            playerInventory.AddItem(allItemInfos[i]);
            transferAmount += 1;
        }

        OnRefreshTransfer?.Invoke(transferAmount * -1);
        buildingpodInventory.MainItemCollection.RemoveAll();        
    }

}
