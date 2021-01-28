﻿/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.Core
{
    /// <summary>
    /// The event names are used by the event handler. The name syntax is defined as:
    /// c_TargetObjectType_EventDescription_Parameter1Type_Parameter2Type_...
    /// </summary>
    public static class EventNames
    {
        //The currency owner updated.
        public const string c_CurrencyOwner_OnUpdate = "CurrencyOwner_OnUpdate";
        //The currency collection updated. 
        public const string c_CurrencyCollection_OnUpdate = "CurrencyCollection_OnUpdate";
        //The currency owner added currency, the parameter is ListSlice<CurrencyAmount>
        public const string c_CurrencyOwnerGameObject_OnAdd_CurrencyAmountListSlice = "CurrencyOwnerGameObject_OnAdd_CurrencyAmountListSlice";
        //The currency owner removed currency, the parameter is ListSlice<CurrencyAmount>
        public const string c_CurrencyOwnerGameObject_OnRemove_CurrencyAmountListSlice = "CurrencyOwnerGameObject_OnRemove_CurrencyAmountListSlice";

        //The Equipper had item equipped or unequipped.
        public const string c_Equipper_OnChange = "Equipper_OnChange";

        //The interactable was interacted with by an interactor.
        public const string c_Interactable_OnInteract_IInteractor = "Interactable_OnInteract_IInteractor";
        //The interactable was selected by an interactor.
        public const string c_Interactable_OnSelect_IInteractor = "Interactable_OnSelect_IInteractor";
        //The interactable was deselected by an interactor.
        public const string c_Interactable_OnDeselect_IInteractor = "Interactable_OnDeselect_IInteractor";

        //The item collection was updated.
        public const string c_ItemCollection_OnUpdate = "ItemCollection_OnUpdate";

        //The item object had its item swapped out by a new one.
        public const string c_ItemObject_OnItemChanged = "ItemObject_OnItemChanged";

        //The inventory was updated.
        public const string c_Inventory_OnUpdate = "Inventory_OnUpdate";
        //The inventory had an item removed.
        public const string c_Inventory_OnRemove_ItemInfo = "Inventory_OnRemove_ItemInfo";
        //The ItemInfo is the origin of the amount being added and the ItemStack is the result of the add.
        public const string c_Inventory_OnAdd_ItemInfo_ItemStack = "Inventory_OnAdd_ItemInfo_ItemStack";
        //The inventory rejected an item from being added.
        public const string c_Inventory_OnRejected_ItemInfo = "Inventory_OnRejected_ItemInfo";
        //The inventory will forcibly remove an item.
        public const string c_Inventory_OnWillForceRemove_ItemInfo = "Inventory_OnWillForceRemove_ItemInfo";
        //The inventory forcibly removed an item.
        public const string c_Inventory_OnForceRemove_ItemInfo = "Inventory_OnForceRemove_ItemInfo";

        //An item is about to be bought bought in the shop by the inventory and the item needs to be added to the inventory.
        public const string c_InventoryGameObject_OnBuyAddItem_Shop_ItemInfo_ActionBoolSucces = "InventoryGameObject_OnBuyAddItem_Shop_ItemInfo_ActionBoolSucces";
        //An item is about the be sold to the shop by an inventory and the item need to be removed from the inventory.
        public const string c_InventoryGameObject_OnSellRemoveItem_ShopBase_ItemInfo_ActionBoolSucces = "InventoryGameObject_OnSellRemoveItem_ShopBase_ItemInfo_ActionBoolSucces";
        //An item was bought in the shop by the inventory.
        public const string c_InventoryGameObject_OnBuyComplete_Shop_ItemInfo = "InventoryGameObject_OnBuyComplete_Shop_ItemInfo";
        //An item was sold to the shop by an inventory.
        public const string c_InventoryGameObject_OnSellComplete_Shop_ItemInfo = "InventoryGameObject_OnSellComplete_Shop_ItemInfo";

        //An item was bought from the shop.
        public const string c_ShopGameObject_OnBuyComplete_BuyerInventory_ItemInfo = "ShopGameObject_OnBuyComplete_BuyerInventory_ItemInfo";
        //An item was sold to the inventory.
        public const string c_ShopGameObject_OnSellComplete_SellerInventory_ItemInfo = "ShopGameObject_OnSellComplete_SellerInventory_ItemInfo";

        //This event is executed when a item is crafted.
        public const string c_InventoryGameObject_OnCraft_CraftingRecipe_CraftingResult = "InventoryGameObject_OnCraft_CraftingRecipe_CraftingResult";
        //This events executes when a CanCraft call is executed.
        public const string c_InventoryGameObject_OnCanCraft_CraftingRecipe_Bool = "InventoryGameObject_OnCanCraft_CraftingRecipe_Bool";
        //The items used as ingredients need to be removed from the inventory before the craft output can be created.
        public const string c_InventoryGameObject_OnCraftRemoveItem_CraftingProecessor_ItemInfoListSlice_ActionBoolSucces = "InventoryGameObject_OnCraftRemoveItem_CraftingProecessor_ItemInfoListSlice_ActionBoolSucces";

        //The panel was opened or closed. The target game object is the panel owner assigned in the PanelManager.
        public const string c_GameObject_OnPanelOpenClose_PanelEventData = "GameObject_OnPanelOpenClose_PanelEventData";
        //Similar to the OpenClose event but only happens if the selected panel is different. Used to know when the panel manager selects a new panel. The target game object is the panel owner assigned in the PanelManager.
        public const string c_GameObject_OnNewPanelSelected_PanelEventData = "GameObject_OnNewPanelSelected_PanelEventData";
        //The gameplay panel was selected or unselected, this event is particularly useful to enable disable character/UI input. The target game object is the panel owner assigned in the PanelManager.
        public const string c_GameObject_OnGameplayPanelSelected_Bool = "GameObject_OnGameplayPanelSelected_Bool";

        //Enable or Disable Character Input (does not enable disable UI inputs)
        public const string c_GameObject_OnEnableCharacterInput_Bool = "GameObject_OnEnableCharacterInput_Bool";
        //The Inventory Input for switching to the previous tab for example.
        public const string c_GameObject_OnInput_Interact = "GameObject_OnInput_Interact";
        //The Inventory Input for switching to the previous tab for example.
        public const string c_GameObject_OnInput_TriggerPrevious = "GameObject_OnInput_TriggerPrevious";
        //The Inventory Input for switching to the next tab for example.
        public const string c_GameObject_OnInput_TriggerNext = "GameObject_OnInput_TriggerNext";
        //The Inventory Input to close the currently selected panel.
        public const string c_GameObject_OnInput_ClosePanel = "GameObject_OnInput_ClosePanel";
        //The Inventory Input to open a panel by name. Use it to open the main menu for example.
        public const string c_GameObject_OnInput_OpenPanel_String = "GameObject_OnInput_OpenPanel_String";
        //The Inventory Input to toggle a panel by name. Use it to toggle the main menu for example.
        public const string c_GameObject_OnInput_TogglePanel_String = "GameObject_OnInput_TogglePanel_String";
        //The Inventory Input for triggering an item action when an item is selected in the UI -1 and 0 are reserved for no input and default click respectively
        public const string c_GameObject_OnInput_ItemAction_Int = "GameObject_OnInput_ItemAction_Int";
        //The Inventory Input game object sends out events. pass the item hotbar slot index as parameter
        public const string c_GameObject_OnInput_HotbarUseItem_Int = "GameObject_OnInput_HotbarUseItem_Int";
        //The Inventory Input game object sends out events. (int itemObjectSlotIndex, int actionIndex)
        public const string c_GameObject_OnInput_UseItemObject_Int_Int = "GameObject_OnInput_UseItemObject_Int_Int";

        //Choose to enable or disable the inventory monitor listening to the inventory.
        public const string c_InventoryGameObject_InventoryMonitorListen_Bool = "InventoryGameObject_InventoryMonitorListen_Bool";

        //This event fires when the Item View Slot Cursor Manager starts to move an item.
        public const string c_ItemViewSlotCursorManagerGameobject_StartMove = "c_ItemViewSlotCursorManagerGameobject_StartMove";
        //This event fires when the Item View Slot Cursor Manager stops to move an item.
        public const string c_ItemViewSlotCursorManagerGameobject_EndMove = "c_ItemViewSlotCursorManagerGameobject_EndMove";

    }
}
