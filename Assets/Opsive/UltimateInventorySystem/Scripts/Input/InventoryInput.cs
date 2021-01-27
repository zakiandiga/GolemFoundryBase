/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.Input
{
    using Opsive.UltimateInventorySystem.Core;
    using System;
    using UnityEngine;
    using EventHandler = Opsive.Shared.Events.EventHandler;

    /// <summary>
    /// The component used to get input from the player to control UI and use items.
    /// </summary>
    public abstract class InventoryInput : MonoBehaviour
    {
        [Tooltip("Enable Disable Character input (Interact, UseItemHotbar, UseIemObject) when the gameplay panel is selected/unselected.")]
        [SerializeField] protected bool m_EnableCharacterInputOnGameplayPanelSelected;

        protected bool m_IsInputActive = true;
        protected bool m_IsCharacterInputActive = true;

        public virtual bool IsInputActive => isActiveAndEnabled && m_IsInputActive;
        public virtual bool IsCharacterInputActive => m_IsCharacterInputActive && IsInputActive;

        protected virtual void Awake()
        {
            EventHandler.RegisterEvent<bool>(gameObject, EventNames.c_GameObject_OnGameplayPanelSelected_Bool, HandleGameplayPanelSelected);
            EventHandler.RegisterEvent<bool>(gameObject, EventNames.c_GameObject_OnEnableCharacterInput_Bool, SetCharacterInputActive);
        }

        protected virtual void OnDestroy()
        {
            EventHandler.UnregisterEvent<bool>(gameObject, EventNames.c_GameObject_OnGameplayPanelSelected_Bool, HandleGameplayPanelSelected);
            EventHandler.UnregisterEvent<bool>(gameObject, EventNames.c_GameObject_OnEnableCharacterInput_Bool, SetCharacterInputActive);
        }

        protected virtual void HandleGameplayPanelSelected(bool isSelected)
        {
            if (m_EnableCharacterInputOnGameplayPanelSelected == false) { return; }

            EventHandler.ExecuteEvent<bool>(gameObject, EventNames.c_GameObject_OnEnableCharacterInput_Bool, isSelected);
        }

        /// <summary>
        /// Set the input active or inactive.
        /// </summary>
        /// <param name="active">Should the input be active?</param>
        public void SetInputActive(bool active)
        {
            m_IsInputActive = active;
        }

        /// <summary>
        /// Set the input active or inactive.
        /// </summary>
        /// <param name="active">Should the input be active?</param>
        public void SetCharacterInputActive(bool active)
        {
            m_IsCharacterInputActive = active;
        }

        /// <summary>
        /// Use the Trigger Previous input.
        /// </summary>
        public virtual void TriggerPrevious()
        {
            EventHandler.ExecuteEvent(gameObject, EventNames.c_GameObject_OnInput_TriggerPrevious);
        }

        /// <summary>
        /// Use the Trigger Next input.
        /// </summary>
        public virtual void TriggerNext()
        {
            EventHandler.ExecuteEvent(gameObject, EventNames.c_GameObject_OnInput_TriggerNext);
        }

        /// <summary>
        /// Use the Close Panel input.
        /// </summary>
        public virtual void ClosePanel()
        {
            EventHandler.ExecuteEvent(gameObject, EventNames.c_GameObject_OnInput_ClosePanel);
        }

        /// <summary>
        /// Use the Open Toggle Panel input.
        /// </summary>
        /// <param name="panelName">The panel name.</param>
        /// <param name="toggle">Toggle on/off or simply open?</param>
        public virtual void OpenTogglePanel(string panelName, bool toggle)
        {
            if (toggle) {
                EventHandler.ExecuteEvent<string>(gameObject, EventNames.c_GameObject_OnInput_TogglePanel_String, panelName);
            } else {
                EventHandler.ExecuteEvent<string>(gameObject, EventNames.c_GameObject_OnInput_OpenPanel_String, panelName);
            }
        }

        /// <summary>
        /// Use an Item Action
        /// </summary>
        /// <param name="index"></param>
        public virtual void UseItemAction(int index)
        {
            EventHandler.ExecuteEvent<int>(gameObject, EventNames.c_GameObject_OnInput_ItemAction_Int, index);
        }

        /// <summary>
        /// Use the Interact Input.
        /// </summary>
        public virtual void Interact()
        {
            if (IsCharacterInputActive == false) { return; }
            EventHandler.ExecuteEvent(gameObject, EventNames.c_GameObject_OnInput_Interact);
        }

        /// <summary>
        /// The input for the quick item at the index provided.
        /// </summary>
        /// <param name="index">The item index.</param>
        /// <returns>True if the input is valid.</returns>
        public virtual void UseHotbarItem(int index)
        {
            if (IsCharacterInputActive == false) { return; }
            EventHandler.ExecuteEvent<int>(gameObject, EventNames.c_GameObject_OnInput_HotbarUseItem_Int, index);
        }

        /// <summary>
        /// Use an item object input.
        /// </summary>
        /// <param name="itemObjectSlotIndex">The item object slot index within the equipper.</param>
        /// <param name="actionIndex">The action index within the item object behaviour handler.</param>
        public virtual void UseItemObject(int itemObjectSlotIndex, int actionIndex)
        {
            if (IsCharacterInputActive == false) { return; }
            EventHandler.ExecuteEvent<int, int>(gameObject, EventNames.c_GameObject_OnInput_UseItemObject_Int_Int, itemObjectSlotIndex, actionIndex);
        }
    }

    /// <summary>
    /// Hot bar input.
    /// </summary>
    [Serializable]
    public struct IndexedInput
    {
        public int Index;
        public KeyStringStandardInput Input;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="index">The hot bar slot index affected by this input.</param>
        /// <param name="input">The input that use the item in the hotbar.</param>
        public IndexedInput(int index, KeyStringStandardInput input)
        {
            Index = index;
            Input = input;
        }

        /// <summary>
        /// Get the input.
        /// </summary>
        /// <returns>The input.</returns>
        public bool GetInput()
        {
            return Input.GetInput();
        }
    }

    /// <summary>
    /// Hot bar input.
    /// </summary>
    [Serializable]
    public struct UsableItemObjectInput
    {
        public int ItemObjectIndex;
        public int ActionIndex;
        public KeyStringStandardInput Input;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="index">The hot bar slot index affected by this input.</param>
        /// <param name="keyStringInput">The input that use the item in the hotbar.</param>
        public UsableItemObjectInput(int itemObjectIndex, int actionIndex, KeyStringStandardInput keyStringInput)
        {
            ItemObjectIndex = itemObjectIndex;
            ActionIndex = actionIndex;
            Input = keyStringInput;
        }

        /// <summary>
        /// Get the input.
        /// </summary>
        /// <returns>The input.</returns>
        public bool GetInput()
        {
            return Input.GetInput();
        }
    }

    /// <summary>
    /// Hot bar input.
    /// </summary>
    [Serializable]
    public struct OpenToggleInput
    {
        public bool Toggle;
        public string PanelName;
        public KeyStringStandardInput Input;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="panelName">The name of the input.</param>
        /// <param name="input">The input that use the item in the hotbar.</param>
        public OpenToggleInput(bool toggle, string panelName, KeyStringStandardInput input)
        {
            Toggle = toggle;
            PanelName = panelName;
            Input = input;
        }

        /// <summary>
        /// Get the input.
        /// </summary>
        /// <returns>The input.</returns>
        public bool GetInput()
        {
            return Input.GetInput();
        }
    }
}