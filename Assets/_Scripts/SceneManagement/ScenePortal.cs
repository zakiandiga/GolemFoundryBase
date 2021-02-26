using System.Collections;
using System;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string currentScene;
    public string destinationScene;
    public int destinationSpawner;

    public static event Action<string, string, int> OnAreaChange;

    private void Start()
    {
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }



    public void AreaChange()
    {
        StartCoroutine(AreaChangeDelay());
    }

    IEnumerator AreaChangeDelay()
    {
        float waitDelay = 0.5f;
        yield return new WaitForSeconds(waitDelay);
        OnAreaChange?.Invoke(currentScene, destinationScene, destinationSpawner);


    }



}
