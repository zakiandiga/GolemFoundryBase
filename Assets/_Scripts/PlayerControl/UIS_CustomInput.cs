namespace Opsive.UltimateInventorySystem.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class UIS_CustomInput : InventoryInput
    {
        //[SerializeField] private InputActionReference interact; //InteractInput - Player
        [SerializeField] private InputActionReference menu; //OpenTogglePanelInput, define each menu button binding - Player
        [SerializeField] private InputActionReference previous; //TriggerPreviousInput - UI
        [SerializeField] private InputActionReference next; //TriggerNextInput - UI
        [SerializeField] private InputActionReference back; //ClosePanelInput - UI        
        [SerializeField] private InputActionReference confirm; //ItemActionInput - UI
        //[SerializeField] private InputActionReference hotbar0; //define hotbars

        //Open specific menu (like Golem Assembly) triggered from interact event
        //action from interact with interactable triggered from PlayerMovement

        private void OnEnable()
        {
            //interact.action.Enable();
            menu.action.Enable();
            previous.action.Enable();
            next.action.Enable();
            back.action.Enable();            
            confirm.action.Enable();
        }

        private void OnDisable()
        {
            //interact.action.Disable();
            menu.action.Disable();
            previous.action.Disable();
            next.action.Disable();
            back.action.Disable();
            confirm.action.Disable();
        }

        private void Update()
        {
            if (IsInputActive == false)
            {
                return;
            }

            //if (interact.action.triggered) //Triggered from player
            //{
            //    Interact();
            //}

            if (previous.action.triggered)
            {
                TriggerPrevious();
            }

            if (next.action.triggered)
            {
                TriggerNext();
            }

            if (back.action.triggered)
            {
                ClosePanel();
            }

            if(menu.action.triggered) //temp
            {
                OpenTogglePanel("Available Parts", true);
            }

            //See InventoryStandardInput.cs for original
            /*
            for (int i = 0; i < m_OpenTogglePanelInput.Length; i++)
            {
                if (m_OpenTogglePanelInput[i].GetInput())
                {
                    OpenTogglePanel(m_OpenTogglePanelInput[i].PanelName, m_OpenTogglePanelInput[i].Toggle);
                }
            }

            for (int i = 0; i < m_ItemActionInput.Length; i++)
            {
                if (m_ItemActionInput[i].GetInput())
                {
                    UseItemAction(m_ItemActionInput[i].Index);
                }
            }

            for (int i = 0; i < m_HotbarInput.Length; i++)
            {
                if (m_HotbarInput[i].GetInput())
                {
                    UseHotbarItem(m_HotbarInput[i].Index);
                }
            }

            for (int i = 0; i < m_UsableItemObjectInput.Length; i++)
            {
                var input = m_UsableItemObjectInput[i];
                if (input.GetInput())
                {
                    UseItemObject(input.ItemObjectIndex, input.ActionIndex);
                }
            }
            */
        }
    }

}
