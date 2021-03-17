using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    [SerializeField] private int lightStatus; //0 = off, 1 = on
    public static event Action <int> OnLightCheck;

    private void Start()
    {
        OnLightCheck?.Invoke(lightStatus);
        Debug.Log("Light status event = " + lightStatus);
    }

    private void OnEnable()
    {
        SceneHandler.OnTransitionFinalized += StartLightCheck;
    }
    
    private void OnDisable()
    {
        SceneHandler.OnTransitionFinalized -= StartLightCheck;
    }

    private void StartLightCheck(string p)
    {

    }
}
