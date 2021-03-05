using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;


public class ScenePortal : MonoBehaviour
{
    private string mainMenu = "MainMenu";
    public string currentScene;
    public int thisSceneDataSlot;
    public string destinationScene;
    public int destinationSpawner;
    SaveSystemMethods saveSystem;

    public static event Action<string, int, string, int> OnAreaChange;

    private void Start()
    {
        //GameObject.DontDestroyOnLoad(this.gameObject);
        saveSystem = GetComponent<SaveSystemMethods>();
    }



    public void AreaChange()
    {
        /*
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene));
        saveSystem.SaveSlot(thisSceneDataSlot);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(mainMenu));
        */

        StartCoroutine(AreaChangeDelay());
    }

    IEnumerator AreaChangeDelay()
    {
        float waitDelay = 0.5f;
        yield return new WaitForSeconds(waitDelay);
        OnAreaChange?.Invoke(currentScene, thisSceneDataSlot, destinationScene, destinationSpawner);


    }



}
