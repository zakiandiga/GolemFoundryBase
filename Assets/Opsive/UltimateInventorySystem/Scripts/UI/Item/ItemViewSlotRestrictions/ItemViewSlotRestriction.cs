/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Item.ItemViewSlotRestrictions
{
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using UnityEngine;

    /// <summary>
    /// A component used to restrict the item which can be added to a slot.
    /// </summary>
    public abstract class ItemViewSlotRestriction : MonoBehaviour
    {
        public abstract bool CanContain(ItemInfo itemInfo);

        /// <summary>
        /// To string custom to show in editor.
        /// </summary>
        /// <returns>The editor.</returns>
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}