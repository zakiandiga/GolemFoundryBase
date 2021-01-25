/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers
{
    using Opsive.Shared.Game;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using UnityEngine;

    /// <summary>
    /// The inventory panel binding.
    /// </summary>
    public abstract class InventoryPanelBinding : DisplayPanelBinding
    {
        [SerializeField] protected bool m_BindToPanelOwnerInventory = true;
        [SerializeField] protected Inventory m_Inventory;

        public Inventory Inventory {
            get => m_Inventory;
            internal set => m_Inventory = value;
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="display">The bound display panel.</param>
        public override void Initialize(DisplayPanel display)
        {
            base.Initialize(display);

            OnInitializeBeforeInventoryBind();

            BindInventory();
        }

        /// <summary>
        /// On Inititalize before the inventory is bound.
        /// </summary>
        protected virtual void OnInitializeBeforeInventoryBind()
        { }

        /// <summary>
        /// Bind the inventory.
        /// </summary>
        public void BindInventory()
        {
            if (m_Inventory != null) {
                BindInventory(m_Inventory);
                return;
            }

            if (m_BindToPanelOwnerInventory) {
                BindInventory(m_DisplayPanel.Manager.PanelOwner.GetCachedComponent<Core.InventoryCollections.Inventory>());
            }
        }

        /// <summary>
        /// Bind the inventory.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public void BindInventory(Inventory inventory)
        {
            m_Inventory = inventory;
            if (m_Inventory == null) {
                Debug.LogWarning("You are binding a Null Inventory, Please make sure the Display Panel Manager, Panel Owner field is set to your main Inventory.");
            }

            OnInventoryBound();
        }

        /// <summary>
        /// The inventory was bound.
        /// </summary>
        protected abstract void OnInventoryBound();
    }
}