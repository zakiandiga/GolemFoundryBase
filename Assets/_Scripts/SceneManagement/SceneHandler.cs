using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers;

public class SceneHandler : MonoBehaviour
{
    private Scene mainMenu;
    private string menuSceneName = "MainMenu";
    private string currentScene;
    private int currentSpawner;
    private int inGameDataSlot = 1;
    private string sceneToUnload;

    public static event Action<string, int> OnSceneLoaded;
    public static event Action<string> OnTransitionFinalized;

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
        mainMenu = SceneManager.GetSceneByName(menuSceneName);

        //DontDestroyOnLoad(gameObject);

        //if(sceneState == SceneState.Start)
        //{
            currentScene = "IndoorDesigner"; //Temporary, to be set from start or load game function
            SaveSystem.LoadAdditiveScene(currentScene);
            sceneState = SceneState.Running;
        //}       
    }

    private void OnEnable()
    {
        TitleManager.OnNewGameCall += LoadNewGame;
        ScenePortal.OnAreaChange += ChangeScene;
        PlayerLocationSetter.OnPlayerRelocationSuccess += SceneTransitionFinalize;
    }

    private void OnDisable()
    {
        TitleManager.OnNewGameCall -= LoadNewGame;
        ScenePortal.OnAreaChange -= ChangeScene;
        PlayerLocationSetter.OnPlayerRelocationSuccess -= SceneTransitionFinalize;
    }

    private void LoadNewGame(TitleManager title)
    {
        sceneToUnload = currentScene;
        currentScene = "IndoorDesigner";
        currentSpawner = 0;
        ChangeScene(sceneToUnload, 1, currentScene, 0);
    }

    private void ChangeScene(string previousScene, int previousSceneDataSlot, string destinationScene, int destinationSpawner)
    {
        sceneToUnload = previousScene; 
        currentScene = destinationScene;
        currentSpawner = destinationSpawner;


        SaveSystem.RecordSavedGameData();
        //SaveSystem.SaveToSlotImmediate(inGameDataSlot);

        SceneManager.sceneLoaded += OnAdditiveSceneLoaded;       

        SaveSystem.LoadAdditiveScene(destinationScene);
    }

    private void OnAdditiveSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnAdditiveSceneLoaded;
        SceneManager.SetActiveScene(scene);  //To make sure the GO with Saver component loaded in this exact scene instead of in main menu

        //The PlayerMover component subscribe to this event to move the player to the new scene
        OnSceneLoaded?.Invoke(currentScene, currentSpawner);
    }

    //This function called when the player successfully move to the new scene (somehow I need to force the player to move before unloading the previous map scene)
    private void SceneTransitionFinalize(PlayerLocationSetter p)
    {
        //SaveSystem.LoadFromSlot(inGameDataSlot);
        SceneManager.SetActiveScene(mainMenu);

        SaveSystem.BeforeSceneChange();
        SaveSystem.UnloadAdditiveScene(sceneToUnload);
        OnTransitionFinalized?.Invoke("SceneHandler");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
