using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLoad : MonoBehaviour
{
    public Transform playerSpawner;
    public Transform golemSpawner;
    GameObject player;
    GameObject blueprintGolemSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //this should be called from enterFactory trigger/function
        player = GameObject.FindWithTag("Player");
        blueprintGolemSpawner = GameObject.FindWithTag("GolemSpawner");
        player.transform.position = playerSpawner.position;
        player.transform.rotation = playerSpawner.rotation;
        blueprintGolemSpawner.transform.position = golemSpawner.position;
    }

}
