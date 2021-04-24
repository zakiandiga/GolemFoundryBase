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
    [SerializeField] private Interactable interactable;
    private bool interactingWithPlayer = false;

    public GameObject impactParticle;
    private ParticleSystem impactVFX;
    

    public int minAmount;
    public int maxAmount;

    public static event Action<Item> OnCheckTool;
    public static event Action<Item, int> OnGatheringMaterial;

    protected override void Start()
    {
        base.Start();
        announcer = GetComponent<InRangeAnnouncer>();
        
        //impactVFX = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        
        CustomEquipper.OnToolChecked += InteractResult;
        PlayerMovement.OnGatheringHit += DeactivateGatheringSpot;

        if (interactable == null) { interactable = GetComponent<Interactable>(); }
        
        interactable.SetIsInteractable(true);
    }

    private void OnDisable()
    {
        CustomEquipper.OnToolChecked -= InteractResult;
        PlayerMovement.OnGatheringHit -= DeactivateGatheringSpot;
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
            interactingWithPlayer = true;
            OnGatheringMaterial?.Invoke(itemResult, UnityEngine.Random.Range(minAmount, maxAmount));            
            
            
        }
        else if (!itemValid)
        {
            Debug.Log("Tool needed!");
        }
    }

    private void DeactivateGatheringSpot(string tool)
    {
        if(interactingWithPlayer == true)
        {
            Debug.Log("Gathering spot deactivated!");
            Instantiate(impactParticle, transform.position, transform.rotation);
            //impactVFX.Play();
            //StartCoroutine(Deactivating())
            interactingWithPlayer = false;
            Deactivate();
            //this.gameObject.SetActive(false); //return to pool
        }

    }

    public override void Deactivate()
    {
        //base.Deactivate();
        interactable.SetIsInteractable(false);
        this.gameObject.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(this.gameObject);       
    }

    protected override void OnInteractInternal(IInteractor interactor)
    {
        //What to do when interacted with?
    }
}
