using Opsive.UltimateInventorySystem.UI.Item;
using UnityEngine;

public class AudioItemViewSlotNavigation : MonoBehaviour
{
    private ItemViewSlot itemViewSlot;    

    [FMODUnity.EventRef] public string Hover;
    [FMODUnity.EventRef] public string Submit;


    // Start is called before the first frame update
    void OnEnable()
    {
        itemViewSlot = GetComponent<ItemViewSlot>();

        itemViewSlot.OnSelectE += PlayHover;
        itemViewSlot.OnSubmitE += PlaySubmit;
    }

    private void OnDisable()
    {
        itemViewSlot.OnSelectE -= PlayHover;
        itemViewSlot.OnSubmitE -= PlaySubmit;
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
