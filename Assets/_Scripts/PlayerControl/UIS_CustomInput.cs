namespace Opsive.UltimateInventorySystem.Input
{
    using System;
    using System.Collections;
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

        public static event Action<string> OnBuildTrigger;
        //public static event Action<string> OnOpenMenu;
        public static event Action<string> OnClosingBuildMenu;
        public static event Action<string> OnCancelBuild;
 
        private BuildingMenuState buildingMenuState = BuildingMenuState.Inactive;
        public enum BuildingMenuState
        {
            BlueprintOption,
            BlueprintGrid,
            Inactive
            
        }

        //Open specific menu (like Golem Assembly) triggered from interact event
        //action from interact with interactable triggered from PlayerMovement
        private void Start()
        {
            buildingMenuState = BuildingMenuState.Inactive;
        }

        private void OnEnable()
        {
            //Control
            //interact.action.Enable();
            //menu.action.Enable();
            //previous.action.Enable();
            //next.action.Enable();
            //back.action.Enable();            
            //confirm.action.Enable();

            //Observer
            PlayerMovement.OnOpenMenu += OpenMenu;
            ItemActionUsingBlueprint.OnBlueprintSelected += BlueprintSelected;
            BuildGolemHandler.OnBuildPressed += OpenMenu;  
        }

        private void OnDisable()
        {
            //interact.action.Disable();
            menu.action.Disable();
            previous.action.Disable();
            next.action.Disable();
            back.action.Disable();
            confirm.action.Disable();

            PlayerMovement.OnOpenMenu -= OpenMenu;
            BuildGolemHandler.OnBuildPressed -= OpenMenu;
        }

        private void DisablingMenuInteraction()
        {
            menu.action.Disable();
            previous.action.Disable();
            next.action.Disable();
            back.action.Disable();
            confirm.action.Disable();
            //Debug.Log("Menu control disabled");
        }

        private void EnablingMenuInteraction()
        {
            menu.action.Enable();
            previous.action.Enable();
            next.action.Enable();
            back.action.Enable();
            confirm.action.Enable();
            //Debug.Log("Menu control enabled");
        }

        private void BlueprintSelected(int value)
        {
            buildingMenuState = BuildingMenuState.BlueprintGrid;
        }

        private void OpenMenu(string announcer)
        {
            switch (buildingMenuState)
            {
                case BuildingMenuState.Inactive: //Open menu from PlayerMovement
                    if(announcer == "player")
                    {
                        OpenTogglePanel("Assembling Menu", true);
                        EnablingMenuInteraction();                        
                        buildingMenuState = BuildingMenuState.BlueprintOption;
                        Debug.Log("CustomInput OpenMenu from " + announcer + ", menuState = " + buildingMenuState);
                    }
                    break;
                case BuildingMenuState.BlueprintOption: //Close menu on blueprint option opened
                    OnClosingBuildMenu?.Invoke("BlueprintOption");
                    DisablingMenuInteraction();
                    OpenTogglePanel("Assembling Menu", true);
                    buildingMenuState = BuildingMenuState.Inactive;
                    break;
                case BuildingMenuState.BlueprintGrid:
                    //Enter to this state controlled by BlueprintSelecter()
                    if(announcer == "button")
                    {
                        OnCancelBuild("blueprintGrid");
                        buildingMenuState = BuildingMenuState.BlueprintOption;
                    }
                    else if (announcer == "buildHandler")
                    {
                        OnClosingBuildMenu?.Invoke("BlueprintOption");
                        DisablingMenuInteraction();
                        OpenTogglePanel("Assembling Menu", true);
                        buildingMenuState = BuildingMenuState.Inactive;
                    }
                    
                    break;

            }


            /*
            if (announcer == "player")
            {
                Debug.Log("Open Menu Triggered");

                StartCoroutine(WaitCameraFromPlayer());
            }

            else if (announcer == "buildHandler")
            {
                Debug.Log("Close menu from build");
                OpenTogglePanel("Assembling Menu", true);
                OnBuildTrigger?.Invoke("UI_Input");
            }
            */            
        }

        IEnumerator WaitCameraFromPlayer()
        {
            float waitTime = 1f;

            yield return new WaitForSeconds(waitTime);
            OpenTogglePanel("Assembling Menu", true);

        }

        public void CancelButton()
        {
            OpenMenu("button");
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
                CancelButton(); //Temporary, this should be on BUILDING MENU
                Debug.Log("Open Menu pressed");
            }

            if(menu.action.triggered) //temp
            {
                CancelButton(); //Temporary, this should be on BUILDING MENU
                Debug.Log("Open Menu pressed");
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
