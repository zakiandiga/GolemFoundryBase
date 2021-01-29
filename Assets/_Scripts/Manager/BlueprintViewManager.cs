using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.UI.Panels.ItemViewSlotContainers;
using Opsive.UltimateInventorySystem.UI.Panels;

public class BlueprintViewManager : MonoBehaviour
{
    [SerializeField] private RectTransform blueprintPanel;
    [SerializeField] private DisplayPanel blueprintLearned;
    [SerializeField] private Inventory buildingPodInventory;
    public List<GameObject> blueprintPrefabs;
    
    private Inventory prefabInventory;

    // Start is called before the first frame update
    void Start()
    {        
        /*
        foreach (GameObject blueprint in blueprintPrefabs)
        {
            ItemViewSlotsContainerPanelBinding blueprintSpawnInventory;
            GameObject blueprintSpawn = Instantiate(blueprint, blueprintPanel);
            blueprintSpawnInventory = blueprintSpawn.GetComponent<ItemViewSlotsContainerPanelBinding>();
            blueprintSpawnInventory.BindInventory();
            blueprintSpawn.SetActive(false);            
        }
        */
    }

    private void OnEnable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected += OpenPanel;
    }

    private void OnDisable()
    {
        ItemActionUsingBlueprint.OnBlueprintSelected -= OpenPanel;
    }

    private void OpenPanel(int value)
    {
        blueprintPrefabs[value].GetComponent<DisplayPanel>().SmartOpen();
        blueprintLearned.SmartClose();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
