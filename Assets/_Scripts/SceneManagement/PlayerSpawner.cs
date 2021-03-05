using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] string thisScene;
    [SerializeField] private int thisPortalNumber;
    [SerializeField] int dataSlot;

    public static event Action<Transform> OnPlayerReadyToMove;

    private void OnEnable()
    {
        SceneHandler.OnSceneLoaded += SpawnPlayer;
    }

    private void OnDisable()
    {
        SceneHandler.OnSceneLoaded -= SpawnPlayer;
    }

    private void SpawnPlayer(string destinationScene, int destinationPortal)
    {        
        if (destinationPortal == thisPortalNumber && destinationScene == thisScene)
        {
            //Debug.Log("CheckSpawner Called! Destination Scene & portal: " + destinationScene + " & " + destinationPortal);            
            OnPlayerReadyToMove?.Invoke(this.transform);            
        }
    }
}
