/// <summary>
/// NOTES: search //CHANGED for lines that needs to be fixed on 1.1.5 UIS
/// </summary>


namespace Opsive.UltimateInventorySystem.Input
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Opsive.Shared.Input;

    public class UIS_CustomInput : InventoryInput
    {
        //[SerializeField] private InputActionReference interact; //InteractInput - Player
        [SerializeField] private InputActionReference menu; //OpenTogglePanelInput, define each menu button binding - Player
        [SerializeField] private InputActionReference previous; //TriggerPreviousInput - UI
        [SerializeField] private InputActionReference next; //TriggerNextInput - UI
        [SerializeField] private InputActionReference back; //ClosePanelInput - UI        
        [SerializeField] private InputActionReference confirm; //ItemActionInput - UI
        //[SerializeField] private InputActionReference hotbar0; //define hotbars

        private int openedBlueprintIndex = 0;


        public static event Action<string> OnBuildTrigger;
        //public static event Action<string> OnOpenMenu;

        public static event Action<string> OnClosingMenu;
        public static event Action<string> OnCancelBuild;
        public static event Action<int> OnBuildCleanup;

        private InventoryMenuState inventoryMenuState = InventoryMenuState.Inactive;
        public enum InventoryMenuState
        {
            Inactive,
            Active
        }
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
            inventoryMenuState = InventoryMenuState.Inactive;
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
            PlayerMovement.OnOpenMenuFromInteract += OpenAssemblyMenu; //NEED UPDATE
            //PlayerMovement.OnOpenMenu += OpenMainMenu; //Might not needed later
            PlayerMovement.OnOpenInventoryMenu += OpenInventoryMenu;
            //PlayerMovement.OnInteract += PlayerInteract;
            ItemActionUsingBlueprint.OnBlueprintSelected += BlueprintSelected;
            BuildGolemHandler.OnBuildPressed += OpenAssemblyMenu;  
        }

        private void OnDisable()
        {
            //interact.action.Disable();
            menu.action.Disable();
            previous.action.Disable();
            next.action.Disable();
            back.action.Disable();
            confirm.action.Disable();

            //PlayerMovement.OnOpenMenu -= OpenAssemblyMenu; //NEED UPDATE
            
            //PlayerMovement.OnOpenMenu -= OpenMainMenu; //Might not needed
            PlayerMovement.OnOpenInventoryMenu -= OpenInventoryMenu;
            //PlayerMovement.OnInteract -= PlayerInteract;
            ItemActionUsingBlueprint.OnBlueprintSelected -= BlueprintSelected;
            BuildGolemHandler.OnBuildPressed -= OpenAssemblyMenu; //Should be fine
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

        private void OpenInventoryMenu(string announcer)
        {

            if (inventoryMenuState != InventoryMenuState.Active)
            {
                inventoryMenuState = InventoryMenuState.Active;
                //OpenTogglePanel("InventoryMenu", true); //CHANGED
                EnablingMenuInteraction();
            }

        }

        /*
        private void PlayerInteract(GameObject playerCurrentInteractable)
        {
            Interact();
        }
        */

        private void BlueprintSelected(int value)
        {
            buildingMenuState = BuildingMenuState.BlueprintGrid;
            openedBlueprintIndex = value;
            //OpenTogglePanel("Available Parts", true); //CHANGED
            Debug.Log(buildingMenuState);
        }
        

        private void OpenAssemblyMenu(string announcer) //should be called from interactable
        {
            switch (buildingMenuState)
            {
                case BuildingMenuState.Inactive: //Open menu from PlayerMovement
                    if(announcer == "player")
                    {
                        //OnOpenMenuFromInteract?.Invoke("Assembling Menu");
                        //OpenTogglePanel("Assembling Menu", true); //CHANGED
                        EnablingMenuInteraction();                        
                        buildingMenuState = BuildingMenuState.BlueprintOption;
                        Debug.Log("CustomInput OpenMenu from " + announcer + ", menuState = " + buildingMenuState);
                    }
                    break;
                case BuildingMenuState.BlueprintOption: //Close menu on blueprint option opened
                    /*
                    OnClosingMenu?.Invoke("BlueprintOption");
                    DisablingMenuInteraction();
                    OpenTogglePanel("Assembling Menu", true);
                    buildingMenuState = BuildingMenuState.Inactive;
                    */
                    OnClosingMenu?.Invoke("BlueprintOption");
                    //OpenTogglePanel("Assembling Menu", true); //CHANGED
                    DisablingMenuInteraction();                    
                    buildingMenuState = BuildingMenuState.Inactive;
                    Debug.Log("Closing Assembling Menu, buildingMenuState = " + buildingMenuState);
                    break;
                case BuildingMenuState.BlueprintGrid:
                    //Enter to this state controlled by BlueprintSelecter()
                    if(announcer == "button")
                    {
                        OnCancelBuild("blueprintGrid");
                        buildingMenuState = BuildingMenuState.BlueprintOption;
                        //OpenTogglePanel("Available Parts", true); //CHANGED
                    }
                    else if (announcer == "buildHandler")
                    {
                        OnClosingMenu?.Invoke("BlueprintOption");
                        OnBuildCleanup.Invoke(openedBlueprintIndex);

                        //OpenTogglePanel("Available Parts", true); //CHANGED
                    
                        //OpenTogglePanel("Assembling Menu", true); //CHANGED

                        openedBlueprintIndex = 0;
                        DisablingMenuInteraction();                        
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
            //OpenTogglePanel("Assembling Menu", true); //CHANGED

        }

        public void CancelButton()
        {
            OpenAssemblyMenu("button");
        }

        private void Update()
        {            
            /* CHAGED
            if (IsInputActive == false)
            {
                return;
            }
            */

            //if (interact.action.triggered) //Triggered from player
            //{
            //    Interact();
            //}

            if (previous.action.triggered)
            {
                //TriggerPrevious(); //CHANGED
                
            }

            if (next.action.triggered)
            {
                //TriggerNext(); //CHANGED
            }

            if (back.action.triggered)
            {
                CancelButton(); //Temporary, this should be on BUILDING MENU

            }

            if(menu.action.triggered) //temp
            {
                //CancelButton(); //Temporary, this should be on BUILDING MENU
                if(inventoryMenuState == InventoryMenuState.Active)
                {
                    inventoryMenuState = InventoryMenuState.Inactive;
                    //OpenTogglePanel("InventoryMenu", true); //DONE
                    DisablingMenuInteraction();
                    OnClosingMenu?.Invoke("InventoryMenu");
                }

                if(buildingMenuState == BuildingMenuState.BlueprintGrid || buildingMenuState == BuildingMenuState.BlueprintOption)
                {
                    CancelButton();
                }

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
