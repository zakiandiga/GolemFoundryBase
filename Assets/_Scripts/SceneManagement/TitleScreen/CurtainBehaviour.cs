using System;
using System.Collections.Generic;
using UnityEngine;

public class CurtainBehaviour : MonoBehaviour
{
    private Animator anim;

    public static event Action<CurtainBehaviour> OnFadeInDone;
    public static event Action<CurtainBehaviour> OnFadeOutDone;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        TitleManager.OnFadeInCalled += FadeIn;
        TitleManager.OnFadeOutCalled += FadeOut;
        SceneHandler.OnTransitionFinalized += FadeIn;
    }

    private void OnDisable()
    {
        TitleManager.OnFadeInCalled -= FadeIn;
        TitleManager.OnFadeOutCalled -= FadeOut;
        SceneHandler.OnTransitionFinalized -= FadeIn;
    }

    private void FadeIn(string source)
    {
        anim.SetTrigger("fadeIn");
    }

    private void FadeOut(string source)
    {
        anim.SetTrigger("fadeOut");
    }

    public void FadeInDone()
    {        
        OnFadeInDone?.Invoke(this);
    }

    public void FadeOutDone()
    {        
        OnFadeOutDone?.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
