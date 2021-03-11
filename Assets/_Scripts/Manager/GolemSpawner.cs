using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolemSpawner : MonoBehaviour
{
    public string targetScene;

    private void OnEnable()
    {
        BuildGolemHandler.OnGolemReadyToSpawn += SpawnGolem;
    }

    private void OnDisable()
    {
        BuildGolemHandler.OnGolemReadyToSpawn -= SpawnGolem;
    }

    private void SpawnGolem(GameObject golem, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedGolem = Instantiate(golem, position, rotation);
        SceneManager.MoveGameObjectToScene(spawnedGolem, SceneManager.GetSceneByName(targetScene));
        Debug.Log("Spawning golem " + golem);
    }
}
