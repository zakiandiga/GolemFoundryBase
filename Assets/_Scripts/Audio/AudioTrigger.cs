using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [FMODUnity.EventRef] public string Event;
    [FMODUnity.EventRef] public string spawnEffect;

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

    public void SpawnGolem()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(spawnEffect, gameObject);
    }
}
