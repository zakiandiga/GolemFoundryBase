using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers;
using Opsive.UltimateInventorySystem.UI.Panels;

//Main function: toggle between Blueprint Learned and Blueprint Grid
public class BlueprintViewManager : MonoBehaviour
{
    [SerializeField] private RectTransform blueprintPanel;
    [SerializeField] private DisplayPanel blueprintLearned;
    [SerializeField] private Inventory buildingPodInventory;
    public List<GameObject> blueprintPrefabs;

    private int selectedBlueprintIndex;
    
    private Inventory prefabInventory;

    void Start()
    {        
        
    }

    private void OnEnable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected += OpenPanel;        
        ItemTransferHandler.OnRefreshTransfer += ClosePanel;
        BuildGolemHandler.OnBuildPressed += ClosingPanelOnBuild;
        
    }

    private void OnDisable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected -= OpenPanel;
        ItemTransferHandler.OnRefreshTransfer -= ClosePanel;
    }

    private void OpenPanel(int value)
    {
        selectedBlueprintIndex = value;
        blueprintPrefabs[selectedBlueprintIndex].GetComponent<DisplayPanel>().SmartOpen();
        blueprintLearned.SmartClose();

    }

    private void ClosingPanelOnBuild(string source)
    {
        ClosePanel(1); //unused parameter
    }

    private void ClosePanel(int itemCount)
    {
        if(selectedBlueprintIndex > 0)
            blueprintPrefabs[selectedBlueprintIndex].GetComponent<DisplayPanel>().SmartClose();

        blueprintLearned.SmartOpen();
    }

}
