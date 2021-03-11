using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateInventorySystem.UI.Panels;


public class MenuControl : MonoBehaviour
{
    [SerializeField] private DisplayPanelManager panelHandler; //From inventory canvas
    [SerializeField] private DisplayPanel availableParts;

    [SerializeField] private InputActionReference menu; //OpenTogglePanelInput, define each menu button binding - Player
    [SerializeField] private InputActionReference previous; //TriggerPreviousInput - UI
    [SerializeField] private InputActionReference next; //TriggerNextInput - UI
    [SerializeField] private InputActionReference back; //ClosePanelInput - UI        
    [SerializeField] private InputActionReference confirm; //ItemActionInput - UI

    private int openedBlueprintIndex = 0;

    public static event Action<string> OnBuildTriggerNEW; //Might be safe to remove
    public static event Action<string> OnClosingMenuNEW;
    public static event Action<string> OnCancelBuildNEW;
    
    public static event Action<int> OnBuildCleanupNEW; //Might be safe to remove

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
    void Start()
    {

    }

    private void OnEnable()
    {
        //Player press M
        PlayerMovement.OnOpenInventoryMenu += OpenInventoryMenu; 
        
        //Player interact with Building Pod
        PlayerMovement.OnOpenMenuFromInteract += OpenBuildingMenu; 

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
        PlayerMovement.OnOpenMenuFromInteract -= OpenBuildingMenu;
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

    private void ClosingInventoryMenu()
    {
        
        panelHandler.ToggleMainMenu();
        DisablingMenuInteraction();
        OnClosingMenuNEW?.Invoke("InventoryMenu");
    }
    #endregion

    #region Building Menu Control
    private void BlueprintSelected(int value)
    {
        buildingMenuState = BuildingMenuState.BlueprintGrid;
        openedBlueprintIndex = value;
        panelHandler.TogglePanel("AvailableParts");

        Debug.Log(availableParts.IsOpen);
    }

    private void OpenBuildingMenu(string announcer)
    {
        switch (buildingMenuState)
        {
            //player interact with Building Pod
            case BuildingMenuState.Inactive:
                if (announcer == "player")
                {
                    panelHandler.TogglePanel("BuildingMenu");
                    EnablingMenuInteraction();
                    buildingMenuState = BuildingMenuState.BlueprintOption;

                    Debug.Log("CustomInput OpenMenu from " + announcer + ", menuState = " + buildingMenuState);
                }
                break;
            
            case BuildingMenuState.BlueprintOption: //player press back during Blueprint Selection
                OnClosingMenuNEW?.Invoke("BlueprintOption");
                panelHandler.TogglePanel("BuildingMenu");
                buildingMenuState = BuildingMenuState.Inactive;

                Debug.Log("Closing Assembling Menu, buildingMenuState = " + buildingMenuState);
                break;
            
            case BuildingMenuState.BlueprintGrid:  //player press back during Blueprint Grid
                if (announcer == "button")
                {
                    OnCancelBuildNEW("blueprintGrid");
                    buildingMenuState = BuildingMenuState.BlueprintOption;                        
                    panelHandler.TogglePanel("AvailableParts");
                }
                else if (announcer == "buildHandler")
                {                   

                    OnClosingMenuNEW?.Invoke("BlueprintOption");
                    OnBuildCleanupNEW.Invoke(openedBlueprintIndex); 
                    
                    panelHandler.TogglePanel("AvailableParts");
                    panelHandler.TogglePanel("BuildingMenu");

                    openedBlueprintIndex = 0;
                    DisablingMenuInteraction();
                    buildingMenuState = BuildingMenuState.Inactive;
                }
                break;           
        }
    }
        
    public void CancelButton()
    {
        OpenBuildingMenu("button"); //Handling cancel building from UI Button
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

        //Panel force close
        if(availableParts.IsOpen && buildingMenuState != BuildingMenuState.BlueprintGrid )
        {
            panelHandler.TogglePanel("AvailableParts");
            Debug.Log("Available parts currently " + availableParts.IsOpen);
        }
    }
}
