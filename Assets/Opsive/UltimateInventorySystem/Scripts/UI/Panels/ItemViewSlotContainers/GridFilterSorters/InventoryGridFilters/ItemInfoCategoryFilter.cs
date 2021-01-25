﻿/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers.GridFilterSorters.InventoryGridFilters
{
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Storage;
    using Opsive.UltimateInventorySystem.UI.Grid;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class ItemInfoCategoryFilter : ItemInfoFilterBase, IDatabaseSwitcher
    {
        [FormerlySerializedAs("m_ItemCategory")]
        [Tooltip("Show items with inherently with category, shows all if null.")]
        [SerializeField] protected DynamicItemCategory m_ShowItemCategory;
        [Tooltip("Any item inherently in that category will be ignored/hidden.")]
        [SerializeField] protected DynamicItemCategory m_HideCategory;
        [Tooltip("The items with the hide category which have this boolean attribute set to true will be shown.")]
        [SerializeField] protected string m_ShowAttributeName;

        public ItemCategory ShowItemCategory {
            get => m_ShowItemCategory;
            set => m_ShowItemCategory = value;
        }

        public ItemCategory HideCategory {
            get => m_HideCategory;
            set => m_HideCategory = value;
        }

        protected virtual void Awake()
        {
            if (m_ShowItemCategory.SerializedValueIsValid == false || m_HideCategory.SerializedValueIsValid == false) {
                Debug.LogWarning("Some of the categories referenced on the item info category filter do not reference the right database", gameObject);
            }
        }

        public override bool Filter(ItemInfo itemInfo)
        {
            if (itemInfo.Item == null) { return true; }

            var show = m_ShowItemCategory.Value == null || m_ShowItemCategory.Value.InherentlyContains(itemInfo.Item);
            var hide = m_HideCategory.Value != null && m_HideCategory.Value.InherentlyContains(itemInfo.Item);

            //Check the show attribute
            if (string.IsNullOrWhiteSpace(m_ShowAttributeName) == false &&
                itemInfo.Item.TryGetAttributeValue(m_ShowAttributeName, out bool showPriority)) {
                if (showPriority) { return true; }
            }

            return !hide && show;
        }

        public override string ToString()
        {
            var show = m_ShowItemCategory.Value == null ? "NULL" : m_ShowItemCategory.Value.name;
            var hide = m_HideCategory.Value == null ? "NULL" : m_HideCategory.Value.name;

            return $"{base.ToString()}:  Show: {show} | Hide: {hide}";
        }

        /// <summary>
        /// Check if the object contained by this component are part of the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>True if all the objects in the component are part of that database.</returns>
        bool IDatabaseSwitcher.IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            if (database == null) { return false; }

            return database.Contains(m_ShowItemCategory.OriginalSerializedValue) && database.Contains(m_HideCategory.OriginalSerializedValue);
        }

        /// <summary>
        /// Replace any object that is not in the database by an equivalent object in the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The objects that have been changed.</returns>
        ModifiedObjectWithDatabaseObjects IDatabaseSwitcher.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            if (database == null) { return null; }

            m_ShowItemCategory = database.FindSimilar(m_ShowItemCategory);
            m_HideCategory = database.FindSimilar(m_HideCategory);

            return null;
        }
    }
}