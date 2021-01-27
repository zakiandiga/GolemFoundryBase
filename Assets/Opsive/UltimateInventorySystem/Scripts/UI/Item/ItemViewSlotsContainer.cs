﻿/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Item
{
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using UnityEngine;

    /// <summary>
    /// The hot item bar component allows you to use an item action for an item that was added to the hot bar.
    /// </summary>
    public class ItemViewSlotsContainer : ItemViewSlotsContainerBase
    {
        [Tooltip("The Item View drawer.")]
        [SerializeField] protected ItemViewDrawer m_ItemViewDrawer;
        [Tooltip("Swap Item Views when Item is assigned.")]
        [SerializeField] protected bool m_SwapItemViewOnAssign;
        [Tooltip("The parent of all the itemBoxSlots.")]
        [SerializeField] protected RectTransform m_Content;

        public RectTransform Content => m_Content;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="force">Force initialize.</param>
        public override void Initialize(bool force)
        {
            if (m_IsInitialized && !force) {
                if (Application.isPlaying) {
                    m_ItemViewDrawer.Content = m_Content;
                    m_ItemViewDrawer.Initialize(force);
                }
                return;
            }

            if (m_Content == null) { m_Content = transform as RectTransform; }

            m_ItemViewSlots = m_Content.GetComponentsInChildren<ItemViewSlot>();

            if (Application.isPlaying) {
                m_ItemViewDrawer.Content = m_Content;
                m_ItemViewDrawer.Initialize(force);
            }

            base.Initialize(force);
        }

        /// <summary>
        /// Assign an item to a slot.
        /// </summary>
        /// <param name="itemInfo">The item.</param>
        /// <param name="slot">The item slot.</param>
        protected override void AssignItemToSlot(ItemInfo itemInfo, int slot)
        {
            if (m_SwapItemViewOnAssign) {
                m_ItemViewDrawer.DrawView(slot, slot, itemInfo, true);
                return;
            }

            base.AssignItemToSlot(itemInfo, slot);
        }

        /// <summary>
        /// Get the Box prefab for the item specified.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <returns>The box prefab game object.</returns>
        public override GameObject GetViewPrefabFor(ItemInfo itemInfo)
        {
            return m_ItemViewDrawer.CategoryItemViewSet.FindItemViewPrefabForItem(itemInfo.Item);
        }
    }
}