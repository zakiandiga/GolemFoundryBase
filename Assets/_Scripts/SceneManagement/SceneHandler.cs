using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;

public class SceneHandler : MonoBehaviour
{
    private string menuSceneName = "MainMenu";
    private string currentScene;
    private int currentSpawner;
    private int inGameDataSlot = 1;
    private string sceneToUnload;

    public static event Action<string, int> OnSceneLoaded;

    public enum SceneState
    {
        Start,
        Running,
        LoadingNext,
        UnloadingPrevious
    }
    private SceneState sceneState = SceneState.Start;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        //if(sceneState == SceneState.Start)
        //{
            currentScene = "MineDesigner"; //Temporary, to be set from start or load game function
            SaveSystem.LoadAdditiveScene(currentScene);
            sceneState = SceneState.Running;
        //}       
    }

    private void OnEnable()
    {
        ScenePortal.OnAreaChange += ChangeScene;
        PlayerLocationSetter.OnPlayerRelocationSuccess += SceneTransitionFinalize;
    }

    private void OnDisable()
    {
        ScenePortal.OnAreaChange -= ChangeScene;
        PlayerLocationSetter.OnPlayerRelocationSuccess -= SceneTransitionFinalize;
    }

    private void ChangeScene(string previousScene, int previousSceneDataSlot, string destinationScene, int destinationSpawner)
    {
        //Store all the values needed
        sceneToUnload = previousScene; 
        currentScene = destinationScene;
        currentSpawner = destinationSpawner;

        //Save the current/previous scene state
        SaveSystem.SaveToSlotImmediate(inGameDataSlot);

        //load next scene while listen to on scene loaded
        SceneManager.sceneLoaded += OnAdditiveSceneLoaded;
        
        SaveSystem.LoadAdditiveScene(destinationScene);
    }

    private void OnAdditiveSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //unsubscribe to the sceneLoaded event
        SceneManager.sceneLoaded -= OnAdditiveSceneLoaded;

        //what to do OnSceneLoaded
        OnSceneLoaded?.Invoke(currentScene, currentSpawner);        
    }

    private void SceneTransitionFinalize(PlayerLocationSetter p)
    {
        if(SaveSystem.HasSavedGameInSlot(inGameDataSlot))
        {
            SaveSystem.LoadFromSlot(inGameDataSlot);
        }        
        
        SaveSystem.UnloadAdditiveScene(sceneToUnload);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
