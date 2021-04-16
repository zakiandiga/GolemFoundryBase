using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject menuPanel;

    public List<GameObject> menus;

    public enum TitleScreenState
    {
        Title,
        MenuOpen,
        NewGame,
        Continue,
        Options,
        Quit
    }
    private TitleScreenState titleScreenState = TitleScreenState.Title;

    public static event Action<string> OnFadeInCalled;
    public static event Action<string> OnFadeOutCalled;

    public static event Action<TitleManager> OnNewGameCall;

    private void Start()
    {

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
        menus[0].SetActive(true);
    }

    private void OnEnable()
    {
        CurtainBehaviour.OnFadeInDone += FadeInHandler;
        CurtainBehaviour.OnFadeOutDone += FadeOutHandler;
    }

    private void OnDisable()
    {
        CurtainBehaviour.OnFadeInDone -= FadeInHandler;
        CurtainBehaviour.OnFadeOutDone -= FadeOutHandler;
    }

    private void FadeInHandler(CurtainBehaviour curtain)
    {

    }

    private void FadeOutHandler(CurtainBehaviour curtain)
    {
        Debug.Log("FadeOutHandler Called");
        switch (titleScreenState)
        {

            case TitleScreenState.MenuOpen:
                menuPanel.SetActive(true);
                titlePanel.SetActive(false);
                FadeIn();
                Debug.Log("We got here");
                break;
            case TitleScreenState.NewGame:
                //menuPanel.SetActive(false);
                OnNewGameCall?.Invoke(this);
                //SceneManager.LoadScene("MainMenu");
                break;

        }

    }

    public void FadeIn()
    {        
        OnFadeInCalled?.Invoke("TitleScreen");    
    }

    public void FadeOut()
    {   
        OnFadeOutCalled?.Invoke("TitleScreen");
    }



    public void PlayButton()
    {
        titleScreenState = TitleScreenState.MenuOpen;
        FadeOut();
        Debug.Log("Play Button clicked!");
        
        //Loading time here
    }

    public void NewGame()
    {
        Debug.Log("New Game pressed");
        titleScreenState = TitleScreenState.NewGame;
        FadeOut();
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
