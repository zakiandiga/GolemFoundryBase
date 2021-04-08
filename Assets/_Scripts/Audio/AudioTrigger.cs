using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Event;
    public bool PlayOnEnable;
    public bool PlayOnDisable;

    public void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (PlayOnEnable)
            PlaySound();
    }

    private void OnDisable()
    {
        if (PlayOnDisable)
            PlaySound();

    }
}
