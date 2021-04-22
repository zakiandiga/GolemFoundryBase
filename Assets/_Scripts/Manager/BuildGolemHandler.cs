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

    public GameObject buildButton;

    public Transform spawner;

    public DisplayPanel assemblingMenu;
    public GameObject availableParts;
    //public GameObject blueprintPanel; //Assign in runtime
    public GameObject targetGolem; //Assign in runtime from blueprintPanel?
    private DisplayPanel blueprintPanel;

    public static event Action<string> OnBuildPressed;
    public static event Action<GameObject, Vector3, Quaternion> OnGolemReadyToSpawn;

    void Start()
    {
        blueprintPanel = GetComponent<DisplayPanel>();
        
        buildButton.SetActive(false);   

    }

    private void OnEnable()
    {
        ItemTransferHandler.OnRefreshTransfer += ResetSlotFill;
        ItemViewDropContainerSmartExchangeActionCustom.OnItemDrop += ItemDropListener;
    }

    private void OnDisable()
    {
        ItemTransferHandler.OnRefreshTransfer -= ResetSlotFill;
        ItemViewDropContainerSmartExchangeActionCustom.OnItemDrop -= ItemDropListener;
    }

    private void ResetSlotFill(int amount)
    {
        currentSlotFill += amount;

        if(currentSlotFill < 0) //negative handler
        {
            currentSlotFill = 0;
        }

        buildButton.SetActive(false);        
        
    }

    private void ItemDropListener(int amount)
    {
        currentSlotFill += amount;
        //Debug.Log("Part dropped! currentSlotFill = " + currentSlotFill);

        if(currentSlotFill >= maxSlotFill)
        {
            ActivateAssemblyButton();
        }        
    }

    private void ActivateAssemblyButton()
    {
        buildButton.SetActive(true);
    }

    public void Build()
    {
        buildButton.SetActive(false);
        OnBuildPressed?.Invoke("buildHandler");
        currentSlotFill = 0;

        OnGolemReadyToSpawn?.Invoke(targetGolem, spawner.position, spawner.rotation);

        //Instantiate(targetGolem, spawner.position, spawner.rotation); //Should we pool this?
        
    }

}
