namespace Opsive.UltimateInventorySystem.UI.Item.DragAndDrop.DropActions
{

    using Opsive.UltimateInventorySystem.UI.Grid;
    using System;
    using UnityEngine;  


    [Serializable]
    public class ItemActionDropAnnouncerCondition : ItemViewDropCondition
    {
        public override bool CanDrop(ItemViewDropHandler itemViewDropHandler)
        {
            // If they are equal items should be moved not exchanged.
            if (itemViewDropHandler.SourceContainer == itemViewDropHandler.DestinationContainer) { return false; }

            //Item Shapes work a bit differently so this needs to return false in case we are using an item shape grid.
            if (itemViewDropHandler.DestinationContainer is ItemShapeGrid) { return false; }

            var sourceCanGive = itemViewDropHandler.SourceContainer.CanGiveItem(
                itemViewDropHandler.SourceItemInfo,
                itemViewDropHandler.SourceIndex);

            var destinationCanGive = itemViewDropHandler.DestinationContainer.CanGiveItem(
                itemViewDropHandler.DestinationItemInfo,
                itemViewDropHandler.DestinationIndex);

            var sourceCanAdd = itemViewDropHandler.SourceContainer.CanAddItem(
                itemViewDropHandler.StreamData.DestinationItemInfo,
                itemViewDropHandler.SourceIndex);

            var destinationCanAdd = itemViewDropHandler.DestinationContainer.CanAddItem(
                itemViewDropHandler.StreamData.SourceItemInfo,
                itemViewDropHandler.DestinationIndex);

            var sourceIsNull = itemViewDropHandler.SourceItemInfo.Item == null;

            var destinationIsNull = itemViewDropHandler.DestinationItemInfo.Item == null;


            if (sourceIsNull && destinationIsNull) { return false; }

            return (sourceCanGive && destinationCanAdd);
        }
    }

    [Serializable]
    public class ItemActionDropAnnouncerAction : ItemViewDropAction
    {
        public static event Action<int> OnItemDrop;

        public override void Drop(ItemViewDropHandler itemViewDropHandler)
        {
            OnItemDrop?.Invoke(1);
            Debug.Log("OnItemDrop Invoked");
        }
    }

}