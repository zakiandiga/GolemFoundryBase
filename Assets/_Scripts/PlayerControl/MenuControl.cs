using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateInventorySystem.UI.Panels;


public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas; //Needed to force close build menu
    [SerializeField] private DisplayPanelManager panelHandler; //From inventory canvas
    [SerializeField] private DisplayPanel availableParts;

    [SerializeField] private InputActionReference menu; //OpenTogglePanelInput, define each menu button binding - Player
    [SerializeField] private InputActionReference previous; //TriggerPreviousInput - UI
    [SerializeField] private InputActionReference next; //TriggerNextInput - UI
    [SerializeField] private InputActionReference back; //ClosePanelInput - UI        
    [SerializeField] private InputActionReference confirm; //ItemActionInput - UI

    private int openedBlueprintIndex = 0;
    private bool buildingMenuOpen = false;

    public static event Action<string> OnBuildTrigger; //Might be safe to remove
    public static event Action<string> OnClosingMenu;
    public static event Action<string> OnCancelBuild;
    
    public static event Action<int> OnBuildCleanup; //Might be safe to remove

    public static event Action<MenuControl> OnDebugMenuControl; //DEBUG

    /// <summary>
    /// State of all menu
    /// Current menu: InventoryMenu, BuildingMenu
    /// </summary>
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
    private CraftingMenuState craftingMenuState = CraftingMenuState.Inactive;
    public enum CraftingMenuState
    {
        Inactive,
        Active
    }

    private void OnEnable()
    {
        //Player press M
        PlayerMovement.OnOpenInventoryMenu += OpenInventoryMenu; 
        
        //Player interact with Building Pod
        PlayerMovement.OnOpenMenuFromInteract += OpenMenuFromInteract; 

        //player choose a blueprint on Blueprint Selection
        ItemActionUsingBlueprint.OnBlueprintSelected += BlueprintSelected;

        //player click on build
        BuildGolemHandler.OnBuildPressed += OpenBuildingMenu;

    }

    private void OnDisable()
    {
        menu.action.Disable();
        previous.action.Disable();
        next.action.Disable();
        back.action.Disable();
        confirm.action.Disable();

        PlayerMovement.OnOpenInventoryMenu -= OpenInventoryMenu;
        PlayerMovement.OnOpenMenuFromInteract -= OpenMenuFromInteract;
        ItemActionUsingBlueprint.OnBlueprintSelected -= BlueprintSelected;
        BuildGolemHandler.OnBuildPressed -= OpenBuildingMenu;
    }

    private void DisablingMenuInteraction()
    {
        menu.action.Disable();
        previous.action.Disable();
        next.action.Disable();
        back.action.Disable();
        confirm.action.Disable();
    }

    private void EnablingMenuInteraction()
    {
        menu.action.Enable();
        previous.action.Enable();
        next.action.Enable();
        back.action.Enable();
        confirm.action.Enable();
    }

    #region Inventory Menu Control
    private void OpenInventoryMenu(string announcer)
    {
        if(inventoryMenuState != InventoryMenuState.Active)
        {
            inventoryMenuState = InventoryMenuState.Active;
            panelHandler.ToggleMainMenu();
            EnablingMenuInteraction();
        }
    }

    public void ExitButton() //Function for Exit Button at Main Menu Tabs
    {
        if (inventoryMenuState == InventoryMenuState.Active)
        {
            //Need switch like Building Menu if Inventory Menu contains child menu later
            inventoryMenuState = InventoryMenuState.Inactive;
            ClosingInventoryMenu();
        }
    }

    private void ClosingInventoryMenu()
    {
        
        panelHandler.ToggleMainMenu();
        DisablingMenuInteraction();
        OnClosingMenu?.Invoke("InventoryMenu");
    }
    #endregion

    private void OpenMenuFromInteract(string announcer) //Interact Menu selector
    {
        switch (announcer)
        {
            case "BuildingMenu":
                OpenBuildingMenu("BuildingMenu");
                break;
            case "CraftingMenu":
                OpenCraftingMenu("CraftingMenu");
                break;
        }
    }


    #region Building Menu Control
    private void BlueprintSelected(int value)
    {
        buildingMenuState = BuildingMenuState.BlueprintGrid;
        openedBlueprintIndex = value;
        //panelHandler.TogglePanel("AvailableParts");
        panelHandler.TogglePanel("AvailableParts");
    }

    private void OpenBuildingMenu(string announcer)
    {
        switch (buildingMenuState)
        {
            //player interact with Building Pod
            case BuildingMenuState.Inactive:
                if (announcer == "BuildingMenu")
                {                    
                    panelHandler.TogglePanel("BuildingMenu");
                    EnablingMenuInteraction();
                    buildingMenuOpen = true;
                    buildingMenuState = BuildingMenuState.BlueprintOption;
                    //Debug.Log("CustomInput OpenMenu from " + announcer + ", menuState = " + buildingMenuState);
                }
                break;
            
            case BuildingMenuState.BlueprintOption: //player press back during Blueprint Selection
                OnClosingMenu?.Invoke("BlueprintOption");
                panelHandler.TogglePanel("BuildingMenu");
                buildingMenuOpen = false;
                buildingMenuState = BuildingMenuState.Inactive;
                //Debug.Log("Closing Assembling Menu, buildingMenuState = " + buildingMenuState);
                break;
            
            case BuildingMenuState.BlueprintGrid:  //player press back or cancel button during Blueprint Grid
                if (announcer == "button")
                {
                    OnCancelBuild?.Invoke("blueprintGrid");
                                          
                    panelHandler.TogglePanel("AvailableParts");
                    openedBlueprintIndex = 0;
                    buildingMenuState = BuildingMenuState.BlueprintOption;
                }
                else if (announcer == "buildHandler")
                {
                    //OnBuildCleanupNEW?.Invoke(openedBlueprintIndex);

                    openedBlueprintIndex = 0;

                    panelHandler.TogglePanel("AvailableParts");
                    panelHandler.TogglePanel("BuildingMenu");
                  
                    //DisablingMenuInteraction();
                    buildingMenuState = BuildingMenuState.Inactive;
                    
                }
                break;           
        }        
    }

    private void ForceCloseBuildMenu()
    {
        panelHandler.TogglePanel("BuildingMenu");

    }

    public void CancelButton()
    {
        OpenBuildingMenu("button"); //Handling cancel building from UI Button
        //OpenBuildingMenu("buildHandler"); //Debugging buildHandler closing
    }
    #endregion

    #region Crafting Menu Control

    private void OpenCraftingMenu(string announcer)
    {        
        switch (craftingMenuState)
        {
            case CraftingMenuState.Inactive:
                if (announcer == "CraftingMenu")
                {
                    panelHandler.TogglePanel("CraftingMenu");
                    EnablingMenuInteraction();
                    craftingMenuState = CraftingMenuState.Active;
                    Debug.Log("crafting menu opened!");
                }
                break;
            case CraftingMenuState.Active:
                OnClosingMenu?.Invoke("CraftingMenu");
                Debug.Log("OnClosingMenuNew Invoke");

                
                panelHandler.TogglePanel("CraftingMenu");
                DisablingMenuInteraction();
                Debug.Log("Disabling Menu Interaction");

                craftingMenuState = CraftingMenuState.Inactive;
                break;
        }
    }

    public void CraftingExitButton()
    {
        OpenCraftingMenu("Input");
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if(back.action.triggered)
        {            
            //Handle cancel button for building menu here later
            if(buildingMenuState == BuildingMenuState.BlueprintGrid)
            {
                CancelButton(); //Same function as UI Cancel button
            }
            else if(buildingMenuState == BuildingMenuState.BlueprintOption)
            {
                OpenBuildingMenu("Input");
            }

            if(inventoryMenuState == InventoryMenuState.Active) 
            {
                //Need switch like Building Menu if Inventory Menu contains child menu later
                inventoryMenuState = InventoryMenuState.Inactive;
                ClosingInventoryMenu();
            }

            if(craftingMenuState == CraftingMenuState.Active)
            {
                OpenCraftingMenu("Input");
            }
        }    

        if(menu.action.triggered) //Might be refactored?
        {
            //Closing currently open Inventory Menu if it's Active
            if (inventoryMenuState == InventoryMenuState.Active)
            {
                inventoryMenuState = InventoryMenuState.Inactive;
                ClosingInventoryMenu();
            }
        }

        if(previous.action.triggered)
        {
            OnDebugMenuControl?.Invoke(this); //DEBUG
        }

        //Available Parts Panel force close (Bug workaround)        
        if(availableParts.IsOpen && buildingMenuState != BuildingMenuState.BlueprintGrid )
        {
            panelHandler.TogglePanel("AvailableParts");
        }

        //Building Menu panel doesn't close on 2nd build bug workaround
        if(inventoryCanvas.activeSelf && buildingMenuState == BuildingMenuState.Inactive && buildingMenuOpen == true) //Force close identifier
        {
            if(panelHandler.GetPanel("BuildingMenu").IsOpen)
            {
                ForceCloseBuildMenu();
            }
            else if (!panelHandler.GetPanel("BuildingMenu").IsOpen && buildingMenuOpen == true)
            {                
                OnClosingMenu?.Invoke("BlueprintOption"); //Tell player movement to enable playerMovement
                buildingMenuOpen = false;
            }
                
        }
        
    }
}
