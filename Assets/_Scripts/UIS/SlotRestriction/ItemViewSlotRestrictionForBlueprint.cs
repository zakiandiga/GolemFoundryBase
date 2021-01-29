using Opsive.UltimateInventorySystem.UI.Item.ItemViewSlotRestrictions;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using UnityEngine;

public class ItemViewSlotRestrictionForBlueprint : ItemViewSlotRestriction
{
    [SerializeField] protected ItemDefinition partSlot;
    
    public override bool CanContain(ItemInfo itemInfo)
    {
        
        if (itemInfo.Item.ItemDefinition == null) { return true; }

        return partSlot == itemInfo.Item.ItemDefinition;
    }
}
