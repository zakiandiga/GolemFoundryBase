using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] string thisScene;
    [SerializeField] private int thisPortalNumber;

    public static event Action<Transform> OnSceneLoaded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        SceneManagement.OnSceneLoaded += SpawnPlayer;
        //OnSceneLoaded?.Invoke(this.transform);
    }

    private void OnDisable()
    {
        SceneManagement.OnSceneLoaded -= SpawnPlayer;
    }



    private void SpawnPlayer(string destinationScene, int destinationPortal)
    {
        Debug.Log("CheckSpawner Called!");
        if(thisPortalNumber == destinationPortal && thisScene == destinationScene)
        {
            OnSceneLoaded?.Invoke(this.transform);
            Debug.Log("Player position updated!");
        }
    }

}
