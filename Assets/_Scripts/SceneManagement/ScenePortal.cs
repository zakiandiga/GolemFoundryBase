using PixelCrushers;
using System;
using System.Collections;
using UnityEngine;


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
        saveSystem = GetComponent<SaveSystemMethods>();
    }

    public void AreaChange()
    {
        StartCoroutine(AreaChangeDelay());
    }

    IEnumerator AreaChangeDelay()
    {
        float waitDelay = 0.5f;
        yield return new WaitForSeconds(waitDelay);
        OnAreaChange?.Invoke(currentScene, thisSceneDataSlot, destinationScene, destinationSpawner);
    }
}
