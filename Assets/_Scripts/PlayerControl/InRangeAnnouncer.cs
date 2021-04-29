using System;
using UnityEngine;

//Put this script on interactable object, like guilding pod
public class InRangeAnnouncer : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerInRange;
    public static event Action<GameObject> OnPlayerOutRange;

    public bool inRange = false;

    public GameObject InteractSign;

    public void PlayerInRange()
    {
        inRange = true;
        OnPlayerInRange?.Invoke(this.gameObject);
        InteractSign.SetActive(true);
    }

    public void PlayerOutRange()
    {
        inRange = false;
        OnPlayerOutRange?.Invoke(this.gameObject);
        InteractSign.SetActive(false);
    }

    public void PlayerEquip()
    {
        InteractSign.SetActive(false);
    }
}
