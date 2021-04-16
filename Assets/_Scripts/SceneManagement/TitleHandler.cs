using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleHandler : MonoBehaviour
{
    [SerializeField] private GameObject TitleCanvas;
    [SerializeField] private GameObject titlePanel, playPanel, transitionCurtain;
    private Animator titleAnim, playAnim, curtainAnim;


    [SerializeField] private Button playButton, newgameButton, continueButton, backButton, quitButton; //Do we need these references?

    public static event Action<string> OnNewGamePressed;

    void Start()
    {
        titleAnim = titlePanel.GetComponent<Animator>();
        playAnim = playPanel.GetComponent<Animator>();
        curtainAnim = transitionCurtain.GetComponent<Animator>();

        playPanel.SetActive(false);

    }

    private void OnEnable()
    {
        SceneHandler.OnGameLoaded += DeactivateTitleScreen;
    }

    private void OnDisable()
    {
        SceneHandler.OnGameLoaded -= DeactivateTitleScreen;
    }


    private void DeactivateTitleScreen(SceneHandler handler)
    {
        TitleCanvas.SetActive(false);
    }    

    //Button functions
    public void PressPlay()
    {
        titlePanel.SetActive(false);
        playPanel.SetActive(true);
        newgameButton.Select();
    }

    public void PressBack()
    {
        playPanel.SetActive(false);
        titlePanel.SetActive(true);
    }

    public void PressNewGame()
    {
        OnNewGamePressed?.Invoke("NewGame");
        curtainAnim.SetTrigger("fadeIn");
    }

    public void PressContinue()
    {
        //continue function here
    }

    public void PressQuit()
    {
        //Quit function here
        Application.Quit();
    }
}
