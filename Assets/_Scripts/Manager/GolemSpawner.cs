using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolemSpawner : MonoBehaviour
{
    public string menuSceneName, targetSceneName;
    Scene menuScene, targetScene;

    private void Start()
    {
        menuScene = SceneManager.GetSceneByName(menuSceneName);
        targetScene = SceneManager.GetSceneByName(targetSceneName);
    }
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
        SceneManager.SetActiveScene(targetScene);
        GameObject spawnedGolem = Instantiate(golem, position, rotation);

        //SceneManager.MoveGameObjectToScene(spawnedGolem, SceneManager.GetSceneByName(targetScene));

        SceneManager.SetActiveScene(menuScene);        
    }
}
