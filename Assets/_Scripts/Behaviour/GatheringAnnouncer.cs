using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Equipping;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateInventorySystem.Core.InventoryCollections;
using Opsive.UltimateInventorySystem.DropsAndPickups;

public class GatheringAnnouncer : PickupBase
{
    public Item toolNeeded;
    public Item itemResult;
    //public GameObject itemResult;
    private InRangeAnnouncer announcer;
    private Interactable interactable;

    public int minAmount;
    public int maxAmount;

    public static event Action<Item> OnCheckTool;
    public static event Action<Item, int> OnGatheringMaterial;

    protected override void Start()
    {
        base.Start();
        announcer = GetComponent<InRangeAnnouncer>();
        interactable = GetComponent<Interactable>();
    }

    private void OnEnable()
    {
        CustomEquipper.OnToolChecked += InteractResult;
        
        //interactable.SetIsInteractable(true);
    }

    private void OnDisable()
    {
        CustomEquipper.OnToolChecked -= InteractResult;
    }

    public void Interacted()
    {        
        OnCheckTool?.Invoke(toolNeeded);
    }

    public override void OnInteract(IInteractor interactor)
    {
        OnInteractInternal(interactor);
        interactor.RemoveInteractable(interactable);
        OnCheckTool?.Invoke(toolNeeded);

    }

    private void InteractResult(bool itemValid)
    {
        if(itemValid)
        {
            Debug.Log("Interact with the Gathering spot");            
            OnGatheringMaterial?.Invoke(itemResult, UnityEngine.Random.Range(minAmount, maxAmount));
            
            
            //announcer.PlayerOutRange(); //Remove this interactable from player interactor
            StartCoroutine(DeactivateGatheringSpot());
        }
        else if (!itemValid)
        {
            Debug.Log("Tool needed!");
        }
    }

    private IEnumerator DeactivateGatheringSpot()
    {
        float delay = 1f;

        yield return new WaitForSeconds(delay);

        Debug.Log("Gathering spot deactivated!");
        Deactivate();
        //this.gameObject.SetActive(false); //return to pool
        
    }



    protected override void OnInteractInternal(IInteractor interactor)
    {
        //What to do when interacted with?
    }
}
