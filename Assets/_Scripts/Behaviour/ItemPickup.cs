using Opsive.UltimateInventorySystem.Interactions;

public class ItemPickup : InteractableBehavior
{
    /// <summary>
    /// can the interactor interact with this component.
    /// </summary>
    /// <param name="interactor">The interactor.</param>
    /// <returns>Returns true if it can interact.</returns>
    public override bool CanInteract(IInteractor interactor)
    {
        return base.CanInteract(interactor);
    }
    /// <summary>
    /// The event called when the interactable is selected by an interactor.
    /// </summary>
    /// <param name="interactor">The interactor.</param>
    public override void OnSelect(IInteractor interactor)
    {
        base.OnSelect(interactor);
        // Do something.
    }
    /// <summary>
    /// The event when the interactable is no longer selected.
    /// </summary>
    /// <param name="interactor">The interactor.</param>
    public override void OnDeselect(IInteractor interactor)
    {
        base.OnDeselect(interactor);
        // Do something.
    }

    /// <summary>
    /// On Interaction.
    /// </summary>
    /// <param name="interactor">The interactor.</param>
    protected override void OnInteractInternal(IInteractor interactor)
    {
        // If you require the interactor to be an inventory interactor.
        if (!(interactor is IInteractorWithInventory interactorWithInventory)) { return; }
        var inventory = interactorWithInventory.Inventory;
        // Do something.
    }
}

