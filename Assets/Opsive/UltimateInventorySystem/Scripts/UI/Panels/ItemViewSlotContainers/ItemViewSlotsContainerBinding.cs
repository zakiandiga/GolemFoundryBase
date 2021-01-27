/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers
{
    using Opsive.UltimateInventorySystem.UI.Item;
    using UnityEngine;

    /// <summary>
    /// Bas class to for object bound to an item view slot container.
    /// </summary>
    public abstract class ItemViewSlotsContainerBinding : MonoBehaviour
    {

        protected ItemViewSlotsContainerBase m_ItemViewSlotsContainer;

        protected bool m_IsInitialized;

        /// <summary>
        /// Initialize.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize(false);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="force">Force Initialize.</param>
        public virtual void Initialize(bool force)
        {
            if (m_IsInitialized && force == false) { return; }

            m_IsInitialized = true;
        }

        /// <summary>
        /// Bind an item view slots container.
        /// </summary>
        /// <param name="container">The container.</param>
        public virtual void Bind(ItemViewSlotsContainerBase container)
        {
            Initialize(false);
            if (m_ItemViewSlotsContainer == container) { return; }

            UnBind();

            m_ItemViewSlotsContainer = container;

            OnBind();

        }

        /// <summary>
        /// Item View Slot Container was bound.
        /// </summary>
        protected abstract void OnBind();

        /// <summary>
        /// Unbind the item view slot container.
        /// </summary>
        public virtual void UnBind()
        {
            Initialize(false);
            if (m_ItemViewSlotsContainer == null) { return; }

            OnUnBind();
            m_ItemViewSlotsContainer = null;
        }

        /// <summary>
        /// The Item View Slot Container was unbound.
        /// </summary>
        protected abstract void OnUnBind();
    }

    /// <summary>
    /// base class for Item View Slots Container Inventory Grid Bindings.
    /// </summary>
    public abstract class ItemViewSlotsContainerInventoryGridBinding : ItemViewSlotsContainerBinding
    {

        protected InventoryGrid m_InventoryGrid;

        /// <summary>
        /// Bind an inventory grid.
        /// </summary>
        /// <param name="container">The inventory grid.</param>
        public override void Bind(ItemViewSlotsContainerBase container)
        {
            Initialize(false);
            if (m_ItemViewSlotsContainer == container) { return; }

            UnBind();

            var inventoryGrid = container as InventoryGrid;
            if (inventoryGrid == null) { return; }

            m_ItemViewSlotsContainer = container;
            m_InventoryGrid = inventoryGrid;

            OnBind();
        }

        /// <summary>
        /// Unbind the inventory.
        /// </summary>
        public override void UnBind()
        {
            Initialize(false);
            if (m_ItemViewSlotsContainer == null) { return; }

            OnUnBind();
            m_ItemViewSlotsContainer = null;
            m_InventoryGrid = null;
        }
    }
}