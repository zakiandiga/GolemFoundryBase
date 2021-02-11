using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private AsyncOperation destinationScene;


    private void Start()
    {
        //EnterFactory();
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
