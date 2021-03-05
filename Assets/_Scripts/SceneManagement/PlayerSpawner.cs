using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] string thisScene;
    [SerializeField] private int thisPortalNumber;
    [SerializeField] int dataSlot;

    public static event Action<Transform> OnPlayerReadyToMove;

    


    private void OnEnable()
    {
        //SceneManagement.OnSceneLoaded += SpawnPlayer;
        //OnSceneLoaded?.Invoke(this.transform);

        SceneManagerPC.OnSceneLoaded += SpawnPlayer;
    }

    private void OnDisable()
    {
        //SceneManagement.OnSceneLoaded -= SpawnPlayer;

        SceneManagerPC.OnSceneLoaded -= SpawnPlayer;
    }



    private void SpawnPlayer(string destinationScene, int destinationPortal)
    {        
        if (destinationPortal == thisPortalNumber && destinationScene == thisScene)
        {
            Debug.Log("CheckSpawner Called! Destination Scene & portal: " + destinationScene + " & " + destinationPortal);
            
            OnPlayerReadyToMove?.Invoke(this.transform);

            
        }
    }


}
