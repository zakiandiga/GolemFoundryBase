using Opsive.Shared.Game;
using Opsive.UltimateInventorySystem.Core.AttributeSystem;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using Opsive.UltimateInventorySystem.ItemActions;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.UI.Panels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemActionUsingBlueprint : ItemAction
{
    //[SerializeField] private DisplayPanel blueprintList;
    //[SerializeField] ItemInfo itemInfoTest;

    public static event Action<int> OnBlueprintSelected;


    protected override bool CanInvokeInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        return true;
    }

    protected override void InvokeActionInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        
        if (itemInfo != null)
        {
            
            var item = itemInfo.Item.TryGetAttributeValue<int>("GolemRecipeIndex", out int value, false, false);
            //Debug.Log(value);
            OnBlueprintSelected?.Invoke(value);
            //buildingPodManager.blueprintPrefabs[value].GetComponent<DisplayPanel>().SmartOpen();
            
        }
        



        //Open the selected blueprint
        //close unwanted menu during golem assembling
    }

}
