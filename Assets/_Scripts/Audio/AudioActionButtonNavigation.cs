using Opsive.UltimateInventorySystem.UI.CompoundElements;
using UnityEngine;

public class AudioActionButtonNavigation : MonoBehaviour
{
    private ActionButton actionButton;

    [FMODUnity.EventRef] public string Hover;
    [FMODUnity.EventRef] public string Submit;

    private void OnEnable()
    {
        actionButton = GetComponent<ActionButton>();
        
        actionButton.OnSelectE += PlayHover;
        actionButton.OnSubmitE += PlaySubmit;
    }

    private void OnDisable()
    {
        actionButton.OnSelectE -= PlayHover;
        actionButton.OnSubmitE -= PlaySubmit;
    }

    private void PlayHover()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Hover, gameObject);
    }

    private void PlaySubmit()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Submit, gameObject);
    }
}
