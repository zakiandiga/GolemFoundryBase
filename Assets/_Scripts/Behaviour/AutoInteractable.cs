namespace Opsive.UltimateInventorySystem.Interactions
{
    using Opsive.UltimateInventorySystem.Core;
    using UnityEngine;
    using UnityEngine.Events;
    using EventHandler = Opsive.Shared.Events.EventHandler;

    public class AutoInteractable : Interactable
    {
        private void OnDisable()
        {
            
        }

        private void OnTriggerStay(Collider other)
        {
            if (!m_3D) { return; }
            OnTriggerStayInternal(other.gameObject);
        }

        private void OnTriggerStayInternal(GameObject other)
        {
            if (!m_IsInteractable || !m_InteractorLayerMask.Contains(other)) { return; }

            var interactor = other.GetComponentInParent<IInteractor>();
            interactor?.AddInteractable(this);
        }

    }

}


