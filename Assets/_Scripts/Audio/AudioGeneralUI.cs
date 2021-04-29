using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class AudioGeneralUI : MonoBehaviour, ISelectHandler
{
    private Button button;

    [FMODUnity.EventRef] public string buttonSelected;
    [FMODUnity.EventRef] public string buttonPressed;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ButtonSelected();
    }

    private void ButtonSelected()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(buttonSelected, gameObject);
    }

    public void ButtonPressed()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(buttonPressed, gameObject);
    }


}
