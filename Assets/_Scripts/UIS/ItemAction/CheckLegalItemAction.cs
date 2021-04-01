using System;
using UnityEngine;
using Opsive.UltimateInventorySystem.ItemActions;
using Opsive.Shared.Game;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using Opsive.UltimateInventorySystem.UI.Item;

[System.Serializable]
public class CheckLegalItemAction : ItemAction
{
    public static event Action<ItemInfo> OnCheckItemInfo;

    protected override bool CanInvokeInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        return true;
        
    }

    /// <summary>
    /// Invoke the action.
    /// </summary>
    /// <param name="itemInfo">The item.</param>
    /// <param name="itemUser">The item user (can be null).</param>
    protected override void InvokeActionInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        var item = itemInfo.Item;
        OnCheckItemInfo?.Invoke(itemInfo);
    }

    
}
