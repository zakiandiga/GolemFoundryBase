using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;

public class SceneManagementOLD : MonoBehaviour
{
    //[SerializeField] private string startingScene, originScene, destinationScene;
    /*
    public AsyncOperation startingScene;
    public AsyncOperation destinationScene;
    public AsyncOperation originScene;
    */

    //private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public static event Action<string, int> OnSceneLoaded;

    private void Start()
    {
        
        //EnterFactory();
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("IndoorDesigner", LoadSceneMode.Additive));
        SceneManager.LoadScene("IndoorDesigner", LoadSceneMode.Additive);
        Debug.Log("IndoorDesigner loaded");

    }

    private void OnEnable()
    {
        ScenePortal.OnAreaChange += ChangeScene;
        
    }

    private void OnDisable()
    {
        ScenePortal.OnAreaChange -= ChangeScene;
    }

    private void ChangeScene(string currentScene, int currentSceneDataSlot, string destinationScene, int destinationSpawner)
    {
        //Open loading screen
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene));
        //SaveSystemMethods.SaveSlot(1);
        StartCoroutine(LoadingNextScene(currentScene, destinationScene, destinationSpawner));
    }

    private IEnumerator LoadingNextScene(string previousScene, string destinationScene, int destinationSpawner)
    {
        Debug.Log("Loading scene: " + destinationScene + " on spawner: " + destinationSpawner);
        
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(destinationScene, LoadSceneMode.Additive);        
        while (!loadingScene.isDone)
        {
            yield return null;
        }

        Debug.Log("LoadingNextScene() Done");
        OnSceneLoaded?.Invoke(destinationScene, destinationSpawner);

        

        StartCoroutine(UnloadPreviousScene(previousScene));
    }


    
    private IEnumerator UnloadPreviousScene(string previousScene)
    {
        AsyncOperation unloadingScene = SceneManager.UnloadSceneAsync(previousScene);
        while(!unloadingScene.isDone)
        {
            yield return null;
        }

        Debug.Log("Unloading " + previousScene + " scene complete!");

        //Close loading screen
    }
    

    public void EnterFactory()
    {
        SceneManager.LoadScene("IndoorDesigner", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

