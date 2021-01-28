using Opsive.Shared.Game;
using Opsive.UltimateInventorySystem.Core.AttributeSystem;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using Opsive.UltimateInventorySystem.ItemActions;
using Opsive.UltimateInventorySystem.UI.Panels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemActionUsingBlueprint : ItemAction
{
    [SerializeField] private DisplayPanel blueprintList;

    protected override bool CanInvokeInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        throw new NotImplementedException();
    }

    protected override void InvokeActionInternal(ItemInfo itemInfo, ItemUser itemUser)
    {
        throw new NotImplementedException();

        //Open the selected blueprint
        //close unwanted menu during golem assembling
    }

}
