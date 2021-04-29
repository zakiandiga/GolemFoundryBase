using System;
using UnityEngine;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Equipping;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateInventorySystem.DropsAndPickups;

public class GatheringAnnouncer : PickupBase
{
    public Item toolNeeded;
    public Item itemResult;


    private InRangeAnnouncer announcer;
    [SerializeField] private Interactable interactable;
    //private IInteractor interactor;
    private bool waitingForResult = false;

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
    }

    private void OnEnable()
    {        
        


        if (interactable == null) 
        { 
            interactable = GetComponent<Interactable>(); 
        }
        
        interactable.SetIsInteractable(true);
    }

    public override void OnInteract(IInteractor interactor)
    {
        CustomEquipper.OnToolChecked += InteractResult;
        PlayerAnimationObserver.OnAnimationDone += DeactivateGatheringSpot;

        OnInteractInternal(interactor);
        interactor.RemoveInteractable(interactable);
        OnCheckTool?.Invoke(toolNeeded);

    }

    private void InteractResult(bool itemValid)
    {
        if (itemValid)
        {
            if (this.waitingForResult)
            {
                Debug.Log("Interact with the Gathering spot");
                OnGatheringMaterial?.Invoke(itemResult, UnityEngine.Random.Range(minAmount, maxAmount));
            }                                
        }
        else if (!itemValid)
        {
            Debug.Log("Tool needed!");
            PlayerAnimationObserver.OnAnimationDone -= DeactivateGatheringSpot;
            CustomEquipper.OnToolChecked -= InteractResult;
        }
    }

    private void DeactivateGatheringSpot(string source)
    {
        PlayerAnimationObserver.OnAnimationDone -= DeactivateGatheringSpot;
        CustomEquipper.OnToolChecked -= InteractResult;

        Debug.Log("Gathering spot deactivated!");
        Vector3 particlePos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
        Instantiate(impactParticle, particlePos, transform.rotation);

        Deactivate();    
    }

    public override void Deactivate()
    {
        interactable.SetIsInteractable(false);
        this.gameObject.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(this.gameObject);       
    }

    protected override void OnInteractInternal(IInteractor interactor)
    {
        this.waitingForResult = true;
        //additional things to do OnInteract
    }
}
