using System;
using UnityEngine;

//Put this script on interactable object, like guilding pod
public class InRangeAnnouncer : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerInRange;
    public static event Action<GameObject> OnPlayerOutRange;
    public GameObject InteractSign;

    public void PlayerInRange()
    {
        OnPlayerInRange?.Invoke(this.gameObject);
        InteractSign.SetActive(true);

    }

    public void PlayerOutRange()
    {
        OnPlayerOutRange?.Invoke(this.gameObject);
        InteractSign.SetActive(false);

    }

    public void PlayerEquip()
    {
        InteractSign.SetActive(false);
    }
}
