using System;
using UnityEngine;

//Put this script on interactable object, like guilding pod
public class InRangeAnnouncer : MonoBehaviour
{
    public static event Action<string> OnPlayerInRange;
    public static event Action<InRangeAnnouncer> OnPlayerOutRange;
    public GameObject InteractSign;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInRange();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerOutRange();
        }
    }

    private void PlayerInRange()
    {
        OnPlayerInRange?.Invoke(this.gameObject.name);
        InteractSign.SetActive(true);

    }

    private void PlayerOutRange()
    {
        OnPlayerOutRange?.Invoke(this);
        InteractSign.SetActive(false);

    }
}
