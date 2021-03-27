using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Opsive.UltimateInventorySystem.UI.Monitors;
using PixelCrushers;

public class SceneHandler : MonoBehaviour
{
    private Scene mainMenu;
    private string menuSceneName = "MainMenu";
    private string currentScene;
    private int currentSpawner;
    private int inGameDataSlot = 1;
    private string sceneToUnload;
    [SerializeField] InventoryMonitor inventoryMonitor;

    public static event Action<int> OnStart; //HACK
    public static event Action<string> OnChangeSceneStart;
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
            OnStart?.Invoke(0); //HACK
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

        inventoryMonitor.StopListening();
        SaveSystem.RecordSavedGameData();
        //SaveSystem.SaveToSlotImmediate(inGameDataSlot);
        OnChangeSceneStart?.Invoke("SceneHandler");

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
        inventoryMonitor.StartListening();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
