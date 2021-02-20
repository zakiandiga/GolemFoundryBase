using System;
using UnityEngine;

//Put this script on interactable object, like guilding pod
public class InRangeAnnouncer : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerInRange;
    public static event Action<GameObject> OnPlayerOutRange;
    public GameObject InteractSign;

    private void Start()
    {
        
    }

    /*
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
    */

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
}
