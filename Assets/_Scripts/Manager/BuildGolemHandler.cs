using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Opsive.UltimateInventorySystem.UI.Item.DragAndDrop.DropActions;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.UI.Panels;
using Opsive.UltimateInventorySystem.UI.CompoundElements;

public class BuildGolemHandler : MonoBehaviour
{
    [SerializeField] private int maxSlotFill;
    [SerializeField] private int currentSlotFill;
    public ActionButton assemblyButton;

    public Transform spawner;
    //public Inventory crafterInventory;

    public DisplayPanel assemblingMenu;
    public GameObject availableParts;
    //public GameObject blueprintPanel; //Assign in runtime
    public GameObject targetGolem; //Assign in runtime from blueprintPanel?
    private DisplayPanel blueprintPanel;

    public static event Action<BuildGolemHandler> OnBuildPressed;

    // Start is called before the first frame update
    void Start()
    {
        blueprintPanel = GetComponent<DisplayPanel>();
        
        assemblyButton.interactable = false;

    }

    private void OnEnable()
    {
        ItemTransferHandler.OnCancelBuild += ResetSlotFill;
        ItemViewDropContainerSmartExchangeActionCustom.OnItemDrop += ItemDropListener;
    }

    private void OnDisable()
    {
        ItemTransferHandler.OnCancelBuild -= ResetSlotFill;
        ItemViewDropContainerSmartExchangeActionCustom.OnItemDrop -= ItemDropListener;
    }

    private void ResetSlotFill(int amount)
    {
        currentSlotFill += amount;

        if(currentSlotFill < 0) //negative handler
        {
            currentSlotFill = 0;
        }

        if (assemblyButton.interactable)
        {
            assemblyButton.interactable = false;
        }
        Debug.Log("currentSlotFill reset to " + currentSlotFill);
    }

    private void ItemDropListener(int amount)
    {
        currentSlotFill += amount;

        if(currentSlotFill >= maxSlotFill)
        {
            ActivateAssemblyButton();
        }
        Debug.Log("Item Dropped, currentSlotFill = " + currentSlotFill);
    }

    private void ActivateAssemblyButton()
    {
        assemblyButton.interactable = true;
    }

    public void Build()
    {
        OnBuildPressed?.Invoke(this);
        //playerPanel.SmartClose();
        //crafterPanel.SmartClose();   
        blueprintPanel.SmartClose();
        assemblingMenu.SmartClose();
        Instantiate(targetGolem, spawner.position, Quaternion.identity); //Should we pool this?
        Debug.Log("Item Assembly Success!");
    }

}
