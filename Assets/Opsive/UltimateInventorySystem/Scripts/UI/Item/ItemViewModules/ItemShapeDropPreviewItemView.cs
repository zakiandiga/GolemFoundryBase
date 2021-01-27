/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.UI.Item.ItemViewModules
{
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.UI.Grid;
    using Opsive.UltimateInventorySystem.UI.Item.DragAndDrop;
    using Opsive.UltimateInventorySystem.UI.Views;
    using UnityEngine;
    using UnityEngine.Serialization;
    using UnityEngine.UI;

    /// <summary>
    /// Item Shape Drop Preview.
    /// </summary>
    public class ItemShapeDropPreviewItemView : ItemViewModule, IItemViewSlotDropHoverSelectable
    {
        [FormerlySerializedAs("m_ShapeItemBox")] [SerializeField] protected ItemShapeItemView m_ShapeItemView;
        [Tooltip("The icon image.")]
        [SerializeField] protected Image m_ItemIcon;
        [Tooltip("The icon image.")]
        [SerializeField] protected Image m_ColorFilter;
        [SerializeField] protected Color m_NoConditionsPassed;
        [SerializeField] protected Color m_ConditionsPassed;

        public ItemShapeGridData InventoryItemShapesGridData => m_ShapeItemView.InventoryItemShapesGridData;

        /// <summary>
        /// Set the item info.
        /// </summary>
        /// <param name="info">The item .</param>
        public override void SetValue(ItemInfo info)
        {
            if (info.Item == null || info.Item.IsInitialized == false) {
                Clear();
                return;
            }
        }

        /// <summary>
        /// Clear the component.
        /// </summary>
        public override void Clear()
        {
            m_ItemIcon.enabled = false;
            m_ColorFilter.enabled = false;
        }

        /// <summary>
        /// Same Container, can the item be moved?
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        /// <returns>Can the items be moved.</returns>
        public bool SameContainerCanMove(ItemViewDropHandler dropHandler)
        {
            var sourcePos = InventoryItemShapesGridData.OneDTo2D(dropHandler.SourceIndex);
            var destinationPos = InventoryItemShapesGridData.OneDTo2D(dropHandler.DestinationIndex);

            if (dropHandler.SourceContainer == dropHandler.DestinationContainer) {
                return InventoryItemShapesGridData.CanMoveIndex(sourcePos, destinationPos);
            }

            return false;
        }

        /// <summary>
        /// Select with an item view drop handler.
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        public virtual void SelectWith(ItemViewDropHandler dropHandler)
        {
            var dropActionAndCondition =
                dropHandler.ItemViewSlotDropActionSet.GetFirstPassingCondition(dropHandler);

            var failedCondition = dropActionAndCondition == null;

            m_ColorFilter.color = failedCondition ? m_NoConditionsPassed : m_ConditionsPassed;
            m_ColorFilter.enabled = true;

            if (dropHandler.SourceContainer == dropHandler.DestinationContainer) {
                if (SameContainerCanMove(dropHandler)) { PreviewCanMove(dropHandler); } else { PreviewCannotMove(dropHandler); }
            }
        }

        /// <summary>
        /// The preview cannot move.
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        protected void PreviewCannotMove(ItemViewDropHandler dropHandler)
        {
            InventoryItemShapesGridData.TryFindAnchorForItem(dropHandler.SourceItemInfo, out var anchor);

            var anchoredSource = dropHandler.SourceContainer.GetItemViewAt(
                InventoryItemShapesGridData.TwoDTo1D(anchor));

            PreviewIcon(anchoredSource, dropHandler.SourceItemInfo);

            PreviewAllIcons(dropHandler, anchoredSource, null, null, null);
        }

        /// <summary>
        /// Preview that the item can move.
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        protected void PreviewCanMove(ItemViewDropHandler dropHandler)
        {
            var sourceItemInfo = dropHandler.StreamData.SourceItemInfo;
            var destinationItemInfo = ItemInfo;

            if (sourceItemInfo.ItemStack == destinationItemInfo.ItemStack) {
                //The same item is being moved, only show the source item.
                destinationItemInfo = ItemInfo.None;
            }

            var sourcePos = InventoryItemShapesGridData.OneDTo2D(dropHandler.SourceIndex);
            var destinationPos = InventoryItemShapesGridData.OneDTo2D(dropHandler.DestinationIndex);

            var sourcePreviewItemViewSlot = dropHandler.SlotCursorManager.SourceItemViewSlot;

            if (destinationItemInfo != ItemInfo.None) {

                // Find the box where the item needs to be previewed from.
                var anchorOffset = InventoryItemShapesGridData.GetAnchorOffset(destinationItemInfo, destinationPos);

                sourcePreviewItemViewSlot = dropHandler.DestinationContainer.GetItemViewSlot(
                    InventoryItemShapesGridData.TwoDTo1D(
                        sourcePos + anchorOffset));

                //Hide the destination anchor if the destination is not the anchor.
                InventoryItemShapesGridData.TryFindAnchorForItem(destinationItemInfo, out var anchor);

                var previousAnchoredDestinationBox = dropHandler.DestinationContainer.GetItemViewAt(
                    InventoryItemShapesGridData.TwoDTo1D(anchor));

                PreviewIcon(previousAnchoredDestinationBox, ItemInfo.None);
            }

            var destinationPreviewBox = View;
            var itemSourceAnchorView = dropHandler.SourceItemViewSlot.ItemView;

            if (sourceItemInfo != ItemInfo.None) {

                // Find the box where the item needs to be previewed from.
                var anchorOffset = InventoryItemShapesGridData.GetAnchorOffset(sourceItemInfo, sourcePos);

                destinationPreviewBox = dropHandler.DestinationContainer.GetItemViewAt(
                    InventoryItemShapesGridData.TwoDTo1D(
                        destinationPos + anchorOffset));

                InventoryItemShapesGridData.TryFindAnchorForItem(sourceItemInfo, out var sourceAnchor);
                itemSourceAnchorView = dropHandler.SourceContainer.GetItemViewAt(
                    InventoryItemShapesGridData.TwoDTo1D(sourceAnchor));
            }

            var itemDestinationAnchorView = dropHandler.DestinationItemView;

            if (destinationItemInfo != ItemInfo.None) {

                // Find the box where the item needs to be previewed from.
                var anchorOffset = InventoryItemShapesGridData.GetAnchorOffset(destinationItemInfo, destinationPos); ;

                InventoryItemShapesGridData.TryFindAnchorForItem(destinationItemInfo, out var destinationAnchor);
                itemDestinationAnchorView = dropHandler.DestinationContainer.GetItemViewAt(
                    InventoryItemShapesGridData.TwoDTo1D(destinationAnchor));

            }

            PreviewIcon(itemDestinationAnchorView, ItemInfo.None);

            PreviewIcon(itemSourceAnchorView, ItemInfo.None);

            PreviewIcon(sourcePreviewItemViewSlot.ItemView, destinationItemInfo);

            PreviewIcon(destinationPreviewBox, sourceItemInfo);

            PreviewAllIcons(dropHandler, itemDestinationAnchorView, sourcePreviewItemViewSlot.ItemView, destinationPreviewBox, itemSourceAnchorView);
        }

        /// <summary>
        /// Preview all the icons on the grid.
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        /// <param name="ignoreView1">Exception 1.</param>
        /// <param name="ignoreView2">Exception 2.</param>
        /// <param name="ignoreView3">Exception 3.</param>
        /// <param name="ignoreView4">Exception 4.</param>
        private void PreviewAllIcons(ItemViewDropHandler dropHandler, View<ItemInfo> ignoreView1, View<ItemInfo> ignoreView2, View<ItemInfo> ignoreView3, View<ItemInfo> ignoreView4)
        {
            var itemViewCount = dropHandler.SourceContainer.GetItemViewSlotCount();
            for (int i = 0; i < itemViewCount; i++) {
                var otherItemView = dropHandler.SourceContainer.GetItemViewAt(i);

                if (ignoreView1 == otherItemView) { continue; }
                if (ignoreView2 == otherItemView) { continue; }
                if (ignoreView3 == otherItemView) { continue; }
                if (ignoreView4 == otherItemView) { continue; }

                if (InventoryItemShapesGridData.GetElementAt(i).IsAnchor) {
                    PreviewIcon(otherItemView, otherItemView.ItemInfo);
                } else { PreviewIcon(otherItemView, ItemInfo.None); }
            }
        }

        /// <summary>
        /// Preview the icon.
        /// </summary>
        /// <param name="view">The item view.</param>
        /// <param name="info">The item info.</param>
        protected virtual void PreviewIcon(View<ItemInfo> view, ItemInfo info)
        {
            var destinationModules = view.Modules;

            for (int i = 0; i < destinationModules.Count; i++) {
                if (destinationModules[i] is ItemShapeDropPreviewItemView destinationPreviewModule) {
                    destinationPreviewModule.PreviewIcon(info);
                }
            }
        }

        /// <summary>
        /// Preview the icon.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        protected virtual void PreviewIcon(ItemInfo itemInfo)
        {
            m_ShapeItemView.SetIcon(itemInfo);
        }

        /// <summary>
        /// Deselect the item.
        /// </summary>
        /// <param name="dropHandler">The drop handler.</param>
        public virtual void DeselectWith(ItemViewDropHandler dropHandler)
        {
            m_ColorFilter.enabled = false;
        }
    }
}