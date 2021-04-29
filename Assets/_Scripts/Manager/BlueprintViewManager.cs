using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers;
using Opsive.UltimateInventorySystem.UI.Panels;
using Opsive.UltimateInventorySystem.Input;

//Main function: toggle between Blueprint Learned and Blueprint Grid
public class BlueprintViewManager : MonoBehaviour
{
    [SerializeField] private DisplayPanelManager panelHandler;

    [SerializeField] private RectTransform blueprintPanel;
    [SerializeField] private DisplayPanel blueprintLearned;
    [SerializeField] private Inventory buildingPodInventory;
    public List<GameObject> blueprintPrefabs;

    private DisplayPanel currentBlueprintPanel;
    private int selectedBlueprintIndex;
    
    private Inventory prefabInventory;

    private bool blueprintGridOpen = false;


    private void OnEnable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected += OpenPanel;        
        ItemTransferHandler.OnRefreshTransfer += ClosePanel;
        MenuControl.OnBuildCleanup += ClosePanel;
        BuildGolemHandler.OnBuildPressed += ClosingPanelOnBuild;        
    }

    private void OnDisable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected -= OpenPanel;
        ItemTransferHandler.OnRefreshTransfer -= ClosePanel;
        MenuControl.OnBuildCleanup -= ClosePanel;
        BuildGolemHandler.OnBuildPressed -= ClosingPanelOnBuild;
    }

    private void OpenPanel(int value)
    {
        selectedBlueprintIndex = value;
        currentBlueprintPanel = blueprintPrefabs[selectedBlueprintIndex].GetComponent<DisplayPanel>();

        currentBlueprintPanel.SmartToggle();

        blueprintGridOpen = true;
        blueprintLearned.SmartClose();
    }

    private void ClosingPanelOnBuild(string source)
    {
        ClosePanel(1); //unused argument
    }

    private void ClosePanel(int itemCount)
    {
        Debug.Log("selectedBlueprintIndex = " + selectedBlueprintIndex);
        if(selectedBlueprintIndex > 0 && blueprintGridOpen == true)
        {            
            //panelHandler.TogglePanel(panelToOpen);
            currentBlueprintPanel.SmartToggle();

            //Debug.Log("PanelToClose = " + panelToOpen);
            //selectedBlueprintIndex = 0; //reset index
            //panelToOpen = null;

            blueprintGridOpen = false;            
        }
            

        blueprintLearned.SmartOpen();
        
    }

    private void ForceClosePanel()
    {
        currentBlueprintPanel.SmartToggle();
    }

    private void Update()
    {
        if (!blueprintGridOpen && selectedBlueprintIndex != 0) //Not sure if this is a good habbit (might be more to come)
        {
            //Force close the window
            if (currentBlueprintPanel.IsOpen)
            {
                ForceClosePanel();
            }                

            else if (!currentBlueprintPanel.IsOpen)
            {
                selectedBlueprintIndex = 0;
            }
        }
    }

}
