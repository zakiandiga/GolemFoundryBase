/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateInventorySystem.Input
{
    using UnityEngine;

    /// <summary>
    /// The component used to get input from the player to control UI and use items.
    /// </summary>
    public class InventoryStandardInput : InventoryInput
    {
        [Tooltip("The Input of Interacting, used by the Inventory Interactor.")]
        [SerializeField]
        protected KeyStringStandardInput m_InteractInput =
            new KeyStringStandardInput("Fire3", KeyCode.E, InputType.Down);
        [Tooltip("The trigger previous input used by the Tab Controller to switch tabs.")]
        [SerializeField]
        protected KeyStringStandardInput m_TriggerPreviousInput =
            new KeyStringStandardInput("", KeyCode.R, InputType.Down);
        [Tooltip("The trigger next input used by the Tab Controller to switch tabs.")]
        [SerializeField]
        protected KeyStringStandardInput m_TriggerNextInput =
            new KeyStringStandardInput("", KeyCode.T, InputType.Down);
        [Tooltip("Close the currently selected panel input.")]
        [SerializeField]
        protected KeyStringStandardInput m_ClosePanelInput =
            new KeyStringStandardInput("Cancel", KeyCode.Escape, InputType.Down);
        [Tooltip("Open or toggle a specific panel.")]
        [SerializeField]
        protected OpenToggleInput[] m_OpenTogglePanelInput = new OpenToggleInput[]
        {
            new OpenToggleInput(true, "Main Menu", new KeyStringStandardInput(null, KeyCode.I, InputType.Down))
        };
        [Tooltip("Input to use an Item Action (could be used in the UI Item Actions Bindings).")]
        [SerializeField] protected IndexedInput[] m_ItemActionInput;
        [Tooltip("Input to use Item Actions in the Item Hotbar.")]
        [SerializeField]
        protected IndexedInput[] m_HotbarInput = new IndexedInput[]
        {
            new IndexedInput(0, new KeyStringStandardInput(null, KeyCode.JoystickButton1, InputType.Down)),
            new IndexedInput(1, new KeyStringStandardInput(null, KeyCode.JoystickButton4, InputType.Down)),
            new IndexedInput(2, new KeyStringStandardInput(null, KeyCode.JoystickButton5, InputType.Down)),
            new IndexedInput(3, new KeyStringStandardInput(null, KeyCode.JoystickButton6, InputType.Down)),
            new IndexedInput(0, new KeyStringStandardInput(null, KeyCode.Alpha1, InputType.Down)),
            new IndexedInput(1, new KeyStringStandardInput(null, KeyCode.Alpha2, InputType.Down)),
            new IndexedInput(2, new KeyStringStandardInput(null, KeyCode.Alpha3, InputType.Down)),
            new IndexedInput(3, new KeyStringStandardInput(null, KeyCode.Alpha4, InputType.Down)),
            new IndexedInput(4, new KeyStringStandardInput(null, KeyCode.Alpha5, InputType.Down)),
            new IndexedInput(5, new KeyStringStandardInput(null, KeyCode.Alpha6, InputType.Down)),
            new IndexedInput(6, new KeyStringStandardInput(null, KeyCode.Alpha7, InputType.Down)),
            new IndexedInput(7, new KeyStringStandardInput(null, KeyCode.Alpha8, InputType.Down)),
            new IndexedInput(8, new KeyStringStandardInput(null, KeyCode.Alpha9, InputType.Down)),
        };
        [Tooltip("Input to use Item Object Behaviors with an Usable Equipped Items Handler.")]
        [SerializeField] protected UsableItemObjectInput[] m_UsableItemObjectInput;

        /// <summary>
        /// Check for the inputs.
        /// </summary>
        private void Update()
        {
            if (IsInputActive == false) {
                return;
            }

            if (m_InteractInput.GetInput()) {
                Interact();
            }

            if (m_TriggerPreviousInput.GetInput()) {
                TriggerPrevious();
            }

            if (m_TriggerNextInput.GetInput()) {
                TriggerNext();
            }

            if (m_ClosePanelInput.GetInput()) {
                ClosePanel();
            }

            for (int i = 0; i < m_OpenTogglePanelInput.Length; i++) {
                if (m_OpenTogglePanelInput[i].GetInput()) {
                    OpenTogglePanel(m_OpenTogglePanelInput[i].PanelName, m_OpenTogglePanelInput[i].Toggle);
                }
            }

            for (int i = 0; i < m_ItemActionInput.Length; i++) {
                if (m_ItemActionInput[i].GetInput()) {
                    UseItemAction(m_ItemActionInput[i].Index);
                }
            }

            for (int i = 0; i < m_HotbarInput.Length; i++) {
                if (m_HotbarInput[i].GetInput()) {
                    UseHotbarItem(m_HotbarInput[i].Index);
                }
            }

            for (int i = 0; i < m_UsableItemObjectInput.Length; i++) {
                var input = m_UsableItemObjectInput[i];
                if (input.GetInput()) {
                    UseItemObject(input.ItemObjectIndex, input.ActionIndex);
                }
            }
        }
    }
}