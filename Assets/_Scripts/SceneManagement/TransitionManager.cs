using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private Animator transition;
    public GameObject curtain;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private bool hasFadeIn = false;

    public List<GameObject> menus;

    private void Start()
    {
        transition = curtain.GetComponent<Animator>();

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
        menus[0].SetActive(true);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInExecution());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutExecution());
    }

    private IEnumerator FadeInExecution()
    {
        transition.SetTrigger("fadeIn");
        yield return new WaitForSeconds(fadeTime);        
    }

    private IEnumerator FadeOutExecution()
    {
        transition.SetTrigger("fadeOut");
        yield return new WaitForSeconds(fadeTime);
    }

    public void PlayButton()
    {
        transition.SetTrigger("fadeOut");
        Debug.Log("Button clicked!");
        //FadeOut();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
