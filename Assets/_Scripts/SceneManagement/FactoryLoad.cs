using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLoad : MonoBehaviour
{
    //This script align golemSpawner on MainMenuScene to the Factory scene
    public Transform playerSpawner;
    public Transform golemSpawner;
    GameObject player;
    GameObject blueprintGolemSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //this should be called from enterFactory trigger/function
        player = GameObject.FindWithTag("Player"); //Player position should be set from start or load game function
        Debug.Log("Player position should be set from start or load game function, currently it is set from FactoryLoad.cs");
                
        blueprintGolemSpawner = GameObject.FindWithTag("GolemSpawner");
        player.transform.position = playerSpawner.position;
        player.transform.rotation = playerSpawner.rotation;
        blueprintGolemSpawner.transform.position = golemSpawner.position;
    }
}
