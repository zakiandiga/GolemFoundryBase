using System;
using UnityEngine;

public class PlayerAnimationObserver : MonoBehaviour
{
    public static event Action<string> OnAnimationDone;

    private PlayerMovement playerMovement;
    private PlayerSound playerSound;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerSound = GetComponentInParent<PlayerSound>();
    }

    public void GatheringAnimation()
    {
        OnAnimationDone?.Invoke("Animation");
        playerSound.GatheringPickaxe();
        Debug.Log("Gathering animation done!");
    }

}
