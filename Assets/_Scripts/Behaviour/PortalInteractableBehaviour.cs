using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateInventorySystem.Core;
using EventHandler = Opsive.Shared.Events.EventHandler;

public class PortalInteractableBehaviour : Interactable
{

    public override bool Interact(IInteractor interactor)
    {
        if (!CanInteract(interactor)) { return false; }

        m_OnDeselect.Invoke();
        m_OnInteract.Invoke();
        interactor?.RemoveInteractable(this);
        EventHandler.ExecuteEvent<IInteractor>(gameObject, EventNames.c_Interactable_OnInteract_IInteractor, interactor);
        return true;
    }
}
